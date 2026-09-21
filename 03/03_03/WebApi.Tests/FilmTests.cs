using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Tests
{
    public class FilmEndpointsTests
    {
        private WebApplicationFactory<FilmController> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<FilmController>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(IFilmRepository));
                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }
                        services.AddSingleton<IFilmRepository, InMemoryFilmRepository>();
                    });
                });
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetFilms_GeeftAlleFilmsMetStatusOk()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetFilms_GeeftVijfSeedFilmsTerug()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films");
            var films = await response.Content.ReadFromJsonAsync<List<Film>>();

            // Assert
            Assert.That(films, Is.Not.Null);
            Assert.That(films!.Count, Is.EqualTo(5));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public async Task GetFilms_InhoudBevatSeedData(int id)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films");
            var films = await response.Content.ReadFromJsonAsync<List<Film>>();

            // Assert
            Assert.That(films, Is.Not.Null);
            var film = films!.FirstOrDefault(f => f.Id == id);
            Assert.That(film, Is.Not.Null);

            switch (id)
            {
                case 1:
                    Assert.That(film.Titel, Is.EqualTo("The Shawshank Redemption"));
                    Assert.That(film.Regisseur, Is.EqualTo("Frank Darabont"));
                    Assert.That(film.Genre, Is.EqualTo("Drama"));
                    Assert.That(film.Speelduur, Is.EqualTo(142));
                    break;
                case 2:
                    Assert.That(film.Titel, Is.EqualTo("Inception"));
                    Assert.That(film.Regisseur, Is.EqualTo("Christopher Nolan"));
                    Assert.That(film.Genre, Is.EqualTo("Sci-Fi"));
                    Assert.That(film.Speelduur, Is.EqualTo(148));
                    break;
                case 3:
                    Assert.That(film.Titel, Is.EqualTo("De Ontdekking van de Hemel"));
                    Assert.That(film.Regisseur, Is.EqualTo("Jeroen Krabbé"));
                    Assert.That(film.Genre, Is.EqualTo("Drama"));
                    Assert.That(film.Speelduur, Is.EqualTo(165));
                    break;
                case 4:
                    Assert.That(film.Titel, Is.EqualTo("Interstellar"));
                    Assert.That(film.Regisseur, Is.EqualTo("Christopher Nolan"));
                    Assert.That(film.Genre, Is.EqualTo("Sci-Fi"));
                    Assert.That(film.Speelduur, Is.EqualTo(169));
                    break;
                case 5:
                    Assert.That(film.Titel, Is.EqualTo("De Avonturen van Pi"));
                    Assert.That(film.Regisseur, Is.EqualTo("Ang Lee"));
                    Assert.That(film.Genre, Is.EqualTo("Avontuur"));
                    Assert.That(film.Speelduur, Is.EqualTo(127));
                    break;
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public async Task GetFilm_MetId_GeeftCorrectFilmMetStatusOk(int id)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/films/{id}");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase(1, "The Shawshank Redemption", "Frank Darabont", "Drama", 142)]
        [TestCase(2, "Inception", "Christopher Nolan", "Sci-Fi", 148)]
        [TestCase(3, "De Ontdekking van de Hemel", "Jeroen Krabbé", "Drama", 165)]
        [TestCase(4, "Interstellar", "Christopher Nolan", "Sci-Fi", 169)]
        [TestCase(5, "De Avonturen van Pi", "Ang Lee", "Avontuur", 127)]
        public async Task GetFilm_MetId_GeeftCorrecteInhoud(int id, string titel, string regisseur, string genre, int speelduur)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/films/{id}");
            var film = await response.Content.ReadFromJsonAsync<Film>();

            // Assert
            Assert.That(film, Is.Not.Null);
            Assert.That(film!.Id, Is.EqualTo(id));
            Assert.That(film.Titel, Is.EqualTo(titel));
            Assert.That(film.Regisseur, Is.EqualTo(regisseur));
            Assert.That(film.Genre, Is.EqualTo(genre));
            Assert.That(film.Speelduur, Is.EqualTo(speelduur));
        }

        [Test]
        public async Task GetFilm_OnbestaandeId_GeeftNotFound()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films/99");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase(6)]
        [TestCase(50)]
        [TestCase(100)]
        public async Task GetFilm_VerschillendeOnbestaandeIds_GeeftNotFound(int id)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/films/{id}");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task GetFilmsByGenre_Drama_GeeftTweeFilmsTerug()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films/genre/Drama");
            var films = await response.Content.ReadFromJsonAsync<List<Film>>();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(films, Is.Not.Null);
            Assert.That(films!.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetFilmsByGenre_SciFi_GeeftTweeFilmsTerug()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films/genre/Sci-Fi");
            var films = await response.Content.ReadFromJsonAsync<List<Film>>();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(films, Is.Not.Null);
            Assert.That(films!.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetFilmsByGenre_Avontuur_GeeftEenFilmTerug()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films/genre/Avontuur");
            var films = await response.Content.ReadFromJsonAsync<List<Film>>();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(films, Is.Not.Null);
            Assert.That(films!.Count, Is.EqualTo(1));
            Assert.That(films[0].Titel, Is.EqualTo("De Avonturen van Pi"));
        }

        [Test]
        public async Task GetFilmsByGenre_Drama_OngevoeligVoorHoofdletters()
        {
            // Act - lowercase
            HttpResponseMessage responseLower = await _client.GetAsync("/films/genre/drama");
            var filmsLower = await responseLower.Content.ReadFromJsonAsync<List<Film>>();

            // Act - uppercase
            HttpResponseMessage responseUpper = await _client.GetAsync("/films/genre/DRAMA");
            var filmsUpper = await responseUpper.Content.ReadFromJsonAsync<List<Film>>();

            // Assert - both should return the same results
            Assert.That(filmsLower, Is.Not.Null);
            Assert.That(filmsUpper, Is.Not.Null);
            Assert.That(filmsLower!.Count, Is.EqualTo(filmsUpper.Count));
        }

        [Test]
        public async Task GetFilmsByGenre_OnbekendGenre_GeeftLegeLijstTerugMetStatusOk()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films/genre/Komede");
            var films = await response.Content.ReadFromJsonAsync<List<Film>>();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(films, Is.Not.Null);
            Assert.That(films!.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetFilmsByGenre_OnbekendGenreGeeftGeen404()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/films/genre/Thriller");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
