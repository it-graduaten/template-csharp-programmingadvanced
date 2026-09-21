using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class MissionEndpointsTests
    {
        private WebApplicationFactory<MissionController> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<MissionController>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetMission_GeeftAlgemeneInformatie()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/mission");
            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Odyssey is klaar voor vertrek!"));
        }

        [Test]
        public async Task GetAstronaut_GeeftPersoonlijkWelkomstbericht()
        {
            // Arrange
            string naam = "Emma";

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/astronaut/{naam}");

            string inhoud =
                await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Astronaut Emma, welkom aan boord van Odyssey!")
            );
        }

        [TestCase("Youssef")]
        [TestCase("Noah")]
        [TestCase("Fatima")]
        public async Task GetAstronaut_VerschillendeAstronauten_GebruiktNaamUitRoute(
            string naam)
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/astronaut/{naam}");

            string inhoud =
                await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo($"Astronaut {naam}, welkom aan boord van Odyssey!")
            );
        }

        [Test]
        public async Task GetBestemming_Maan_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/mission/bestemming/maan");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("De Maan is de natuurlijke satelliet van de aarde.")
            );
        }

        [Test]
        public async Task GetBestemming_Mars_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/mission/bestemming/mars");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Mars staat bekend als de rode planeet.")
            );
        }

        [Test]
        public async Task GetBestemming_Europa_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/mission/bestemming/europa");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Europa is een maan van Jupiter en heeft een bevroren oppervlak.")
            );
        }

        [TestCase("europa2")]
        [TestCase("ganymedes")]
        [TestCase("callisto")]
        public async Task GetBestemming_OnbekendeBestemming_GeeftStandaardbericht(
            string bestemming)
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/bestemming/{bestemming}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Deze bestemming is niet opgenomen in de Odyssey-missie.")
            );
        }

        [Test]
        public async Task GetReis_MaanBijnaBereikt_GeeftCorrectBericht()
        {
            // Arrange
            string bestemming = "maan";
            int afstand = 500;

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/reis/{bestemming}/{afstand}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Odyssey heeft maan bijna bereikt!"));
        }

        [Test]
        public async Task GetReis_Onderweg_GeeftCorrectBericht()
        {
            // Arrange
            string bestemming = "maan";
            int afstand = 50000;

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/reis/{bestemming}/{afstand}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Odyssey is onderweg naar maan."));
        }

        [Test]
        public async Task GetReis_LangeReis_GeeftCorrectBericht()
        {
            // Arrange
            string bestemming = "mars";
            int afstand = 250000;

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/reis/{bestemming}/{afstand}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Odyssey heeft nog een lange reis naar mars voor de boeg."));
        }

        [TestCase(0)]
        [TestCase(100)]
        [TestCase(999)]
        public async Task GetReis_MinderDan1000km_BijnaBereikt(
            int afstand)
        {
            // Arrange
            string bestemming = "maan";

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/reis/{bestemming}/{afstand}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo($"Odyssey heeft {bestemming} bijna bereikt!"));
        }

        [TestCase(1000)]
        [TestCase(50000)]
        [TestCase(100000)]
        public async Task GetReis_Tussen1000En100000km_Onderweg(
            int afstand)
        {
            // Arrange
            string bestemming = "maan";

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/reis/{bestemming}/{afstand}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Odyssey is onderweg naar maan."));
        }

        [TestCase(100001)]
        [TestCase(250000)]
        [TestCase(500000)]
        public async Task GetReis_MeerDan100000km_LangeReis(
            int afstand)
        {
            // Arrange
            string bestemming = "mars";

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/mission/reis/{bestemming}/{afstand}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Odyssey heeft nog een lange reis naar mars voor de boeg."));
        }
    }
}
