using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class PizzeriaEndpointsTests
    {
        private WebApplicationFactory<PizzeriaController> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<PizzeriaController>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetPizzeria_GeeftSpecialiteit()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/pizzeria");
            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("De specialiteit van Pizza Palazzo is de Pizza Palazzo Special."));
        }

        [Test]
        public async Task GetFormaat_Small_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/pizzeria/formaat/small");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Een small pizza heeft een diameter van 20 cm.")
            );
        }

        [Test]
        public async Task GetFormaat_Medium_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/pizzeria/formaat/medium");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Een medium pizza heeft een diameter van 30 cm.")
            );
        }

        [Test]
        public async Task GetFormaat_Large_GeeftCorrecteInformatie()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/pizzeria/formaat/large");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Een large pizza heeft een diameter van 40 cm.")
            );
        }

        [TestCase("xlarge")]
        [TestCase("jumbo")]
        [TestCase("mini")]
        public async Task GetFormaat_OnbekendFormaat_GeeftStandaardbericht(
            string formaat)
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/pizzeria/formaat/{formaat}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Dit pizzaformaat bestaat niet.")
            );
        }

        [Test]
        public async Task GetKeuze_GeeftPersoonlijkBericht()
        {
            // Arrange
            string naam = "Emma";
            string pizza = "Margherita";

            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/pizzeria/keuze/{naam}/{pizza}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Emma kiest voor een pizza Margherita. Smakelijk!"));
        }

        [TestCase("Youssef", "Diavola")]
        [TestCase("Sofia", "Quattro Formaggi")]
        [TestCase("Lucas", "Hawaï")]
        public async Task GetKeuze_VerschillendeNamenEnPizza_GebruiktRouteparameters(
            string naam, string pizza)
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/pizzeria/keuze/{naam}/{pizza}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo($"{naam} kiest voor een pizza {pizza}. Smakelijk!"));
        }

        [Test]
        public async Task GetPrijs_Small_GeeftCorrectePrijs()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/pizzeria/prijs/small");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Een small pizza kost €8."));
        }

        [Test]
        public async Task GetPrijs_Medium_GeeftCorrectePrijs()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/pizzeria/prijs/medium");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Een medium pizza kost €11."));
        }

        [Test]
        public async Task GetPrijs_Large_GeeftCorrectePrijs()
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync("/pizzeria/prijs/large");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inhoud, Is.EqualTo("Een large pizza kost €14."));
        }

        [TestCase("xlarge")]
        [TestCase("jumbo")]
        [TestCase("mini")]
        public async Task GetPrijs_OnbekendFormaat_GeeftStandaardbericht(
            string formaat)
        {
            // Act
            HttpResponseMessage response =
                await _client.GetAsync($"/pizzeria/prijs/{formaat}");

            string inhoud = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                inhoud,
                Is.EqualTo("Voor dit pizzaformaat is geen prijs beschikbaar.")
            );
        }
    }
}
