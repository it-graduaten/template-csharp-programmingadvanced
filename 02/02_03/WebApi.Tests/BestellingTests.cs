using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests
{
    public class BestellingEndpointsTests
    {
        private WebApplicationFactory<BestellingController> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<BestellingController>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetBestellingen_GeeftAlleBestellingenMetStatusOk()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/bestellingen");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetBestellingen_GeeftDrieSeedBestellingenTerug()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/bestellingen");
            var bestellingen = await response.Content.ReadFromJsonAsync<List<Bestelling>>();

            // Assert
            Assert.That(bestellingen, Is.Not.Null);
            Assert.That(bestellingen!.Count, Is.EqualTo(3));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetBestelling_MetId_GeeftCorrectBestellingMetStatusOk(int id)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/bestellingen/{id}");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase(1, "Anna Jansen", 4, "Lasagne-Salade", "Gereed")]
        [TestCase(2, "Youssef Benali", 7, "Risotto-Gegrilde Groenten", "Bereiden")]
        [TestCase(3, "Maria De Smet", 2, "Pasta Carbonara", "Gereed")]
        public async Task GetBestelling_MetId_GeeftCorrecteInhoud(int id, string naam, int tafelnummer, string gerechten, string status)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/bestellingen/{id}");
            var bestelling = await response.Content.ReadFromJsonAsync<Bestelling>();

            // Assert
            Assert.That(bestelling, Is.Not.Null);
            Assert.That(bestelling!.Id, Is.EqualTo(id));
            Assert.That(bestelling.Naam, Is.EqualTo(naam));
            Assert.That(bestelling.Tafelnummer, Is.EqualTo(tafelnummer));
            Assert.That(bestelling.Gerechten, Is.EqualTo(gerechten));
            Assert.That(bestelling.Status, Is.EqualTo(status));
        }

        [Test]
        public async Task GetBestelling_OnbestaandeId_GeeftNotFound()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/bestellingen/99");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase(4)]
        [TestCase(50)]
        [TestCase(100)]
        public async Task GetBestelling_VerschillendeOnbestaandeIds_GeeftNotFound(int id)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/bestellingen/{id}");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task PutBestelling_BijwerktAllePropertiesEnGeeftNoContent()
        {
            // Arrange - first verify the order exists with original values
            HttpResponseMessage getResponse = await _client.GetAsync("/bestellingen/2");
            var origineleBestelling = await getResponse.Content.ReadFromJsonAsync<Bestelling>();

            // Arrange - send updated data
            var body = new Bestelling { Id = 2, Naam = "Youssef Benali", Tafelnummer = 7, Gerechten = "Risotto-Gegrilde Groenten", Status = "Gereed" };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage putResponse = await _client.PutAsync("/bestellingen/2", content);

            // Assert - immediate response
            Assert.That(putResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

            // Assert - follow-up GET shows updated values
            HttpResponseMessage getAfterResponse = await _client.GetAsync("/bestellingen/2");
            var bijgewerkteBestelling = await getAfterResponse.Content.ReadFromJsonAsync<Bestelling>();

            Assert.That(bijgewerkteBestelling!.Id, Is.EqualTo(2));
            Assert.That(bijgewerkteBestelling.Naam, Is.EqualTo("Youssef Benali"));
            Assert.That(bijgewerkteBestelling.Tafelnummer, Is.EqualTo(7));
            Assert.That(bijgewerkteBestelling.Gerechten, Is.EqualTo("Risotto-Gegrilde Groenten"));
            Assert.That(bijgewerkteBestelling.Status, Is.EqualTo("Gereed"));
        }

        [Test]
        public async Task PutBestelling_WijzigtMeerderePropertiesTegelijk()
        {
            // Arrange - send data where multiple properties change
            var body = new Bestelling { Id = 1, Naam = "Anna Jansen", Tafelnummer = 5, Gerechten = "Lasagne-Salade-Glas", Status = "InBereiding" };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage putResponse = await _client.PutAsync("/bestellingen/1", content);

            // Assert
            Assert.That(putResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

            // Verify all changed properties via GET
            HttpResponseMessage getResponse = await _client.GetAsync("/bestellingen/1");
            var bestelling = await getResponse.Content.ReadFromJsonAsync<Bestelling>();

            Assert.That(bestelling!.Id, Is.EqualTo(1));
            Assert.That(bestelling.Naam, Is.EqualTo("Anna Jansen"));
            Assert.That(bestelling.Tafelnummer, Is.EqualTo(5));
            Assert.That(bestelling.Gerechten, Is.EqualTo("Lasagne-Salade-Glas"));
            Assert.That(bestelling.Status, Is.EqualTo("InBereiding"));
        }

        [Test]
        public async Task PutBestelling_OnbestaandeId_GeeftNotFound()
        {
            // Arrange
            var body = new Bestelling { Id = 99, Naam = "Onbekend", Tafelnummer = 1, Gerechten = "Onbekend", Status = "Onbekend" };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage putResponse = await _client.PutAsync("/bestellingen/99", content);

            // Assert
            Assert.That(putResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase(4)]
        [TestCase(50)]
        [TestCase(100)]
        public async Task PutBestelling_VerschillendeOnbestaandeIds_GeeftNotFound(int id)
        {
            // Arrange
            var body = new Bestelling { Id = id, Naam = "Onbekend", Tafelnummer = 1, Gerechten = "Onbekend", Status = "Onbekend" };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage putResponse = await _client.PutAsync($"/bestellingen/{id}", content);

            // Assert
            Assert.That(putResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task DeleteBestelling_VerwijdertOrderEnGeeftNoContent()
        {
            // Arrange - verify the order exists before deletion using existing seed data
            HttpResponseMessage getBeforeResponse = await _client.GetAsync("/bestellingen/1");
            Assert.That(getBeforeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // Act
            HttpResponseMessage deleteResponse = await _client.DeleteAsync("/bestellingen/1");

            // Assert - immediate response
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

            // Assert - follow-up GET returns NotFound
            HttpResponseMessage getAfterResponse = await _client.GetAsync("/bestellingen/1");
            Assert.That(getAfterResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task DeleteBestelling_NaDelete_GeeftNotFoundVoorCollection()
        {
            // Arrange - verify the order exists in the collection before deletion using existing seed data
            HttpResponseMessage getBeforeResponse = await _client.GetAsync("/bestellingen");
            var bestellingenBefore = await getBeforeResponse.Content.ReadFromJsonAsync<List<Bestelling>>();
            var bestaatVoor = bestellingenBefore!.Any(b => b.Id == 1);
            Assert.That(bestaatVoor, Is.True);

            // Act
            HttpResponseMessage deleteResponse = await _client.DeleteAsync("/bestellingen/1");

            // Act - check the order is no longer in the collection
            HttpResponseMessage getAfterResponse = await _client.GetAsync("/bestellingen");
            var bestellingenAfter = await getAfterResponse.Content.ReadFromJsonAsync<List<Bestelling>>();

            // Assert
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That(bestellingenAfter!.Any(b => b.Id == 1), Is.False);
        }

        [Test]
        public async Task DeleteBestelling_OnbestaandeId_GeeftNotFound()
        {
            // Act
            HttpResponseMessage deleteResponse = await _client.DeleteAsync("/bestellingen/99");

            // Assert
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase(4)]
        [TestCase(50)]
        [TestCase(100)]
        public async Task DeleteBestelling_VerschillendeOnbestaandeIds_GeeftNotFound(int id)
        {
            // Act
            HttpResponseMessage deleteResponse = await _client.DeleteAsync($"/bestellingen/{id}");

            // Assert
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
