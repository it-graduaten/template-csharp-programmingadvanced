using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class FestivalEndpointsTests
    {
        private WebApplicationFactory<FestivalController> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<FestivalController>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetFestival_GeeftAlgemeenWelkomstbericht()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/festival");
            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Welkom op SoundWave Festival!"));
        }

        [Test]
        public async Task GetWelkom_MetNaam_GeeftPersoonlijkWelkomstbericht()
        {
            // Arrange
            string naam = "Emma";

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/festival/welkom/{naam}");

            string inhoud =
                await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.That(
                inhoud,
                Is.EqualTo("Welkom op SoundWave Festival, Emma!")
            );
        }

        [TestCase("Noah")]
        [TestCase("Fatima")]
        [TestCase("Yuki")]
        public async Task GetWelkom_MetVerschillendeNamen_GebruiktNaamUitRoute(
            string naam)
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/festival/welkom/{naam}");

            string inhoud =
                await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo($"Welkom op SoundWave Festival, {naam}!")
            );
        }

        [Test]
        public async Task GetPodium_Main_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/festival/podium/main");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo(
                    "Op het Main Stage spelen de grootste artiesten van het festival."
                )
            );
        }

        [Test]
        public async Task GetPodium_Rock_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/festival/podium/rock");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo(
                    "Op het Rock Stage hoor je gitaren, drums en stevige muziek."
                )
            );
        }

        [Test]
        public async Task GetPodium_Dance_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/festival/podium/dance");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo(
                    "Op het Dance Stage spelen DJ's en elektronische artiesten."
                )
            );
        }

        [TestCase("mainstage")]
        [TestCase("acoustic")]
        [TestCase("jazz")]
        public async Task GetPodium_OnbekendPodium_GeeftStandaardbericht(
            string podium)
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/festival/podium/{podium}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Dit podium bestaat niet.")
            );
        }

        [Test]
        public async Task GetAftellen_GeeftCorrecteCountdown()
        {
            // Arrange
            int dagen = 12;

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/festival/aftellen/{dagen}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Nog 12 dagen tot SoundWave Festival!")
            );
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(30)]
        [TestCase(100)]
        public async Task GetAftellen_VerschillendeDagen_GebruiktGetalUitRoute(
            int dagen)
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/festival/aftellen/{dagen}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo($"Nog {dagen} dagen tot SoundWave Festival!")
            );
        }
    }
}
