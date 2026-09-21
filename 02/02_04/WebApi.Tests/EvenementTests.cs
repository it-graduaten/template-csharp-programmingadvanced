using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests
{
    public class EvenementEndpointsTests
    {
        private WebApplicationFactory<EvenementController> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<EvenementController>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetEvenementen_GeeftAlleEvenementenMetStatusOk()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/evenementen");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetEvenementen_GeeftDrieSeedEvenementenTerug()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/evenementen");
            var evenementen = await response.Content.ReadFromJsonAsync<List<Evenement>>();

            // Assert
            Assert.That(evenementen, Is.Not.Null);
            Assert.That(evenementen!.Count, Is.EqualTo(3));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetEvenement_MetId_GeeftCorrectEvenementMetStatusOk(int id)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/evenementen/{id}");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase(1, "Summer Music Festival", "Antwerpen", "15-07-2026", 5000, 3200)]
        [TestCase(2, "Culinaire Dagen", "Brugge", "22-08-2026", 200, 145)]
        [TestCase(3, "Tech Conference", "Gent", "10-09-2026", 300, 300)]
        public async Task GetEvenement_MetId_GeeftCorrecteInhoud(int id, string naam, string locatie, string datum, int maxDeelnemers, int geregistreerdeDeelnemers)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/evenementen/{id}");
            var evenement = await response.Content.ReadFromJsonAsync<Evenement>();

            // Assert
            Assert.That(evenement, Is.Not.Null);
            Assert.That(evenement!.Id, Is.EqualTo(id));
            Assert.That(evenement.Naam, Is.EqualTo(naam));
            Assert.That(evenement.Locatie, Is.EqualTo(locatie));
            Assert.That(evenement.Datum, Is.EqualTo(datum));
            Assert.That(evenement.MaxDeelnemers, Is.EqualTo(maxDeelnemers));
            Assert.That(evenement.GeregistreerdeDeelnemers, Is.EqualTo(geregistreerdeDeelnemers));
        }

        [Test]
        public async Task GetEvenement_OnbestaandeId_GeeftNotFound()
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync("/evenementen/99");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase(4)]
        [TestCase(50)]
        [TestCase(100)]
        public async Task GetEvenement_VerschillendeOnbestaandeIds_GeeftNotFound(int id)
        {
            // Act
            HttpResponseMessage response = await _client.GetAsync($"/evenementen/{id}");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task PostEvenement_GeeftCreatedMetStatus201()
        {
            // Arrange
            var body = new Evenement { Id = 0, Naam = "Boekenfestival", Locatie = "Leuven", Datum = "05-10-2026", MaxDeelnemers = 150, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync("/evenementen", content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async Task PostEvenement_GeeftTerugHetGemaakteEvenement()
        {
            // Arrange
            var body = new Evenement { Id = 0, Naam = "Boekenfestival", Locatie = "Leuven", Datum = "05-10-2026", MaxDeelnemers = 150, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync("/evenementen", content);
            var evenement = await response.Content.ReadFromJsonAsync<Evenement>();

            // Assert
            Assert.That(evenement, Is.Not.Null);
            Assert.That(evenement!.Naam, Is.EqualTo("Boekenfestival"));
            Assert.That(evenement.Locatie, Is.EqualTo("Leuven"));
            Assert.That(evenement.Datum, Is.EqualTo("05-10-2026"));
            Assert.That(evenement.MaxDeelnemers, Is.EqualTo(150));
            Assert.That(evenement.GeregistreerdeDeelnemers, Is.EqualTo(0));
        }

        [Test]
        public async Task PostEvenement_BerekentIdAlsMaxPlusEen()
        {
            // Arrange - get current max ID first
            HttpResponseMessage getResponse = await _client.GetAsync("/evenementen");
            var evenementen = await getResponse.Content.ReadFromJsonAsync<List<Evenement>>();

            int maxId = evenementen!.Max(e => e.Id);

            var body = new Evenement { Id = 0, Naam = "Boekenfestival", Locatie = "Leuven", Datum = "05-10-2026", MaxDeelnemers = 150, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync("/evenementen", content);
            var evenement = await response.Content.ReadFromJsonAsync<Evenement>();

            // Assert
            Assert.That(evenement!.Id, Is.EqualTo(maxId + 1));
        }

        [Test]
        public async Task PostEvenement_IgnoreertIdUitRequestBody()
        {
            // Arrange - send an event with id=999 which should be ignored
            var body = new Evenement { Id = 999, Naam = "Boekenfestival", Locatie = "Leuven", Datum = "05-10-2026", MaxDeelnemers = 150, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync("/evenementen", content);
            var evenement = await response.Content.ReadFromJsonAsync<Evenement>();

            // Assert - the returned ID should not be 999
            Assert.That(evenement!.Id, Is.Not.EqualTo(999));
        }

        [Test]
        public async Task PostEvenement_GeeftLocationHeaderNaarGemaakteResource()
        {
            // Arrange
            var body = new Evenement { Id = 0, Naam = "Boekenfestival", Locatie = "Leuven", Datum = "05-10-2026", MaxDeelnemers = 150, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync("/evenementen", content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Headers.Location, Is.Not.Null);
        }

        [Test]
        public async Task PostEvenement_LocationHeaderGeeftNaarJuisteRoute()
        {
            // Arrange
            var body = new Evenement { Id = 0, Naam = "Boekenfestival", Locatie = "Leuven", Datum = "05-10-2026", MaxDeelnemers = 150, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync("/evenementen", content);
            var evenement = await response.Content.ReadFromJsonAsync<Evenement>();

            // Assert - Location header should point to the newly created event
            var location = response.Headers.Location!.ToString();
            Assert.That(location, Does.Contain($"/evenementen/{evenement!.Id}"));
        }

        [Test]
        public async Task PostEvenement_NaCreate_GeeftEvenementTerugViaGet()
        {
            // Arrange
            var body = new Evenement { Id = 0, Naam = "Boekenfestival", Locatie = "Leuven", Datum = "05-10-2026", MaxDeelnemers = 150, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act - create the event
            HttpResponseMessage postResponse = await _client.PostAsync("/evenementen", content);
            var evenement = await postResponse.Content.ReadFromJsonAsync<Evenement>();

            // Act - get the event by its returned ID
            int createdId = evenement!.Id;
            HttpResponseMessage getResponse = await _client.GetAsync($"/evenementen/{createdId}");
            var retrievedEvenement = await getResponse.Content.ReadFromJsonAsync<Evenement>();

            // Assert
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(retrievedEvenement!.Id, Is.EqualTo(createdId));
            Assert.That(retrievedEvenement.Naam, Is.EqualTo("Boekenfestival"));
            Assert.That(retrievedEvenement.Locatie, Is.EqualTo("Leuven"));
            Assert.That(retrievedEvenement.Datum, Is.EqualTo("05-10-2026"));
            Assert.That(retrievedEvenement.MaxDeelnemers, Is.EqualTo(150));
            Assert.That(retrievedEvenement.GeregistreerdeDeelnemers, Is.EqualTo(0));
        }

        [Test]
        public async Task PostEvenement_NaCreate_VerschenenInCollectie()
        {
            // Arrange
            var body = new Evenement { Id = 0, Naam = "Boekenfestival", Locatie = "Leuven", Datum = "05-10-2026", MaxDeelnemers = 150, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act - get count before
            HttpResponseMessage getBeforeResponse = await _client.GetAsync("/evenementen");
            var evenementenBefore = await getBeforeResponse.Content.ReadFromJsonAsync<List<Evenement>>();

            // Act - create the event
            HttpResponseMessage postResponse = await _client.PostAsync("/evenementen", content);

            // Act - get count after
            HttpResponseMessage getAfterResponse = await _client.GetAsync("/evenementen");
            var evenementenAfter = await getAfterResponse.Content.ReadFromJsonAsync<List<Evenement>>();

            // Assert
            Assert.That(evenementenAfter!.Count, Is.EqualTo(evenementenBefore!.Count + 1));
        }

        [Test]
        public async Task PostEvenement_MetVerschillendeData_GeeftCorrecteId()
        {
            // Arrange - first create one event to verify ID calculation works for subsequent events
            var body1 = new Evenement { Id = 0, Naam = "Eerste Festival", Locatie = "Antwerpen", Datum = "01-01-2026", MaxDeelnemers = 100, GeregistreerdeDeelnemers = 0 };
            var content1 = new StringContent(System.Text.Json.JsonSerializer.Serialize(body1), System.Text.Encoding.UTF8);
            content1.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage post1Response = await _client.PostAsync("/evenementen", content1);
            var evenement1 = await post1Response.Content.ReadFromJsonAsync<Evenement>();

            // Arrange - get current max ID after first creation
            int maxIdAfterFirst = evenement1!.Id;

            // Act - create second event
            var body2 = new Evenement { Id = 0, Naam = "Tweede Festival", Locatie = "Brugge", Datum = "02-02-2026", MaxDeelnemers = 200, GeregistreerdeDeelnemers = 0 };
            var content2 = new StringContent(System.Text.Json.JsonSerializer.Serialize(body2), System.Text.Encoding.UTF8);
            content2.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage post2Response = await _client.PostAsync("/evenementen", content2);
            var evenement2 = await post2Response.Content.ReadFromJsonAsync<Evenement>();

            // Assert
            Assert.That(evenement2!.Id, Is.EqualTo(maxIdAfterFirst + 1));
        }

        [Test]
        public async Task PutEvenement_BijwerktAllePropertiesEnGeeftNoContent()
        {
            // Arrange - first create a new event for PUT testing
            var createBody = new Evenement { Id = 0, Naam = "Origineel Evenement", Locatie = "Antwerpen", Datum = "01-06-2026", MaxDeelnemers = 500, GeregistreerdeDeelnemers = 100 };
            var createContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(createBody), System.Text.Encoding.UTF8);
            createContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage createResponse = await _client.PostAsync("/evenementen", createContent);
            var createdEvenement = await createResponse.Content.ReadFromJsonAsync<Evenement>();
            int eventId = createdEvenement!.Id;

            // Arrange - send updated data
            var body = new Evenement { Id = eventId, Naam = "Bijgewerkt Evenement", Locatie = "Gent", Datum = "15-09-2026", MaxDeelnemers = 1000, GeregistreerdeDeelnemers = 500 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage putResponse = await _client.PutAsync($"/evenementen/{eventId}", content);

            // Assert - immediate response
            Assert.That(putResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

            // Assert - follow-up GET shows updated values
            HttpResponseMessage getResponse = await _client.GetAsync($"/evenementen/{eventId}");
            var bijgewerktEvenement = await getResponse.Content.ReadFromJsonAsync<Evenement>();

            Assert.That(bijgewerktEvenement!.Id, Is.EqualTo(eventId));
            Assert.That(bijgewerktEvenement.Naam, Is.EqualTo("Bijgewerkt Evenement"));
            Assert.That(bijgewerktEvenement.Locatie, Is.EqualTo("Gent"));
            Assert.That(bijgewerktEvenement.Datum, Is.EqualTo("15-09-2026"));
            Assert.That(bijgewerktEvenement.MaxDeelnemers, Is.EqualTo(1000));
            Assert.That(bijgewerktEvenement.GeregistreerdeDeelnemers, Is.EqualTo(500));
        }

        [Test]
        public async Task PutEvenement_OnbestaandeId_GeeftNotFound()
        {
            // Arrange
            var body = new Evenement { Id = 99, Naam = "Onbekend", Locatie = "Onbekend", Datum = "01-01-2026", MaxDeelnemers = 0, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage putResponse = await _client.PutAsync("/evenementen/99", content);

            // Assert
            Assert.That(putResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase(999)]
        [TestCase(1000)]
        [TestCase(1001)]
        public async Task PutEvenement_VerschillendeOnbestaandeIds_GeeftNotFound(int id)
        {
            // Arrange
            var body = new Evenement { Id = id, Naam = "Onbekend", Locatie = "Onbekend", Datum = "01-01-2026", MaxDeelnemers = 0, GeregistreerdeDeelnemers = 0 };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            HttpResponseMessage putResponse = await _client.PutAsync($"/evenementen/{id}", content);

            // Assert
            Assert.That(putResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task DeleteEvenement_VerwijdertEventEnGeeftNoContent()
        {
            // Arrange - first create a new event for DELETE testing
            var createBody = new Evenement { Id = 0, Naam = "Te Verwijderen Evenement", Locatie = "Antwerpen", Datum = "01-06-2026", MaxDeelnemers = 500, GeregistreerdeDeelnemers = 100 };
            var createContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(createBody), System.Text.Encoding.UTF8);
            createContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage createResponse = await _client.PostAsync("/evenementen", createContent);
            var createdEvenement = await createResponse.Content.ReadFromJsonAsync<Evenement>();
            int eventId = createdEvenement!.Id;

            // Arrange - verify the event exists before deletion
            HttpResponseMessage getBeforeResponse = await _client.GetAsync($"/evenementen/{eventId}");
            Assert.That(getBeforeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // Act
            HttpResponseMessage deleteResponse = await _client.DeleteAsync($"/evenementen/{eventId}");

            // Assert - immediate response
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

            // Assert - follow-up GET returns NotFound
            HttpResponseMessage getAfterResponse = await _client.GetAsync($"/evenementen/{eventId}");
            Assert.That(getAfterResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task DeleteEvenement_NaDelete_GeeftNotFoundVoorCollection()
        {
            // Arrange - first create a new event for DELETE testing
            var createBody = new Evenement { Id = 0, Naam = "Te Verwijderen Evenement", Locatie = "Antwerpen", Datum = "01-06-2026", MaxDeelnemers = 500, GeregistreerdeDeelnemers = 100 };
            var createContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(createBody), System.Text.Encoding.UTF8);
            createContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage createResponse = await _client.PostAsync("/evenementen", createContent);
            var createdEvenement = await createResponse.Content.ReadFromJsonAsync<Evenement>();
            int eventId = createdEvenement!.Id;

            // Arrange - verify the event exists in the collection before deletion
            HttpResponseMessage getBeforeResponse = await _client.GetAsync("/evenementen");
            var evenementenBefore = await getBeforeResponse.Content.ReadFromJsonAsync<List<Evenement>>();
            var bestaatVoor = evenementenBefore!.Any(e => e.Id == eventId);
            Assert.That(bestaatVoor, Is.True);

            // Act
            HttpResponseMessage deleteResponse = await _client.DeleteAsync($"/evenementen/{eventId}");

            // Act - check the event is no longer in the collection
            HttpResponseMessage getAfterResponse = await _client.GetAsync("/evenementen");
            var evenementenAfter = await getAfterResponse.Content.ReadFromJsonAsync<List<Evenement>>();

            // Assert
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That(evenementenAfter!.Any(e => e.Id == eventId), Is.False);
        }

        [Test]
        public async Task DeleteEvenement_OnbestaandeId_GeeftNotFound()
        {
            // Act
            HttpResponseMessage deleteResponse = await _client.DeleteAsync("/evenementen/99");

            // Assert
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase(999)]
        [TestCase(1000)]
        [TestCase(1001)]
        public async Task DeleteEvenement_VerschillendeOnbestaandeIds_GeeftNotFound(int id)
        {
            // Act
            HttpResponseMessage deleteResponse = await _client.DeleteAsync($"/evenementen/{id}");

            // Assert
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task FullCrudLifecycle_CreateReadUpdateDelete()
        {
            // Arrange - create a new event
            var createBody = new Evenement { Id = 0, Naam = "Festival", Locatie = "Antwerpen", Datum = "01-07-2026", MaxDeelnemers = 1000, GeregistreerdeDeelnemers = 50 };
            
            var createContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(createBody), System.Text.Encoding.UTF8);
            createContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Step 1: POST - create the event
            HttpResponseMessage postResponse = await _client.PostAsync("/evenementen", createContent);
            var evenement = await postResponse.Content.ReadFromJsonAsync<Evenement>();
            int eventId = evenement!.Id;

            Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            // Step 2: GET - read the created event
            HttpResponseMessage getResponse = await _client.GetAsync($"/evenementen/{eventId}");
            var retrievedEvenement = await getResponse.Content.ReadFromJsonAsync<Evenement>();

            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(retrievedEvenement!.Id, Is.EqualTo(eventId));
            Assert.That(retrievedEvenement.Naam, Is.EqualTo("Festival"));

            // Step 3: PUT - update the event
            var updateBody = new Evenement { Id = eventId, Naam = "Bijgewerkt Festival", Locatie = "Gent", Datum = "15-08-2026", MaxDeelnemers = 2000, GeregistreerdeDeelnemers = 100 };
            
            var updateContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(updateBody), System.Text.Encoding.UTF8);
            updateContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage putResponse = await _client.PutAsync($"/evenementen/{eventId}", updateContent);

            Assert.That(putResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

            // Step 4: GET - verify the update
            HttpResponseMessage getAfterPutResponse = await _client.GetAsync($"/evenementen/{eventId}");
            var updatedEvenement = await getAfterPutResponse.Content.ReadFromJsonAsync<Evenement>();

            Assert.That(getAfterPutResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(updatedEvenement!.Id, Is.EqualTo(eventId));
            Assert.That(updatedEvenement.Naam, Is.EqualTo("Bijgewerkt Festival"));
            Assert.That(updatedEvenement.Locatie, Is.EqualTo("Gent"));
            Assert.That(updatedEvenement.MaxDeelnemers, Is.EqualTo(2000));

            // Step 5: DELETE - delete the event
            HttpResponseMessage deleteResponse = await _client.DeleteAsync($"/evenementen/{eventId}");

            // Step 6: GET - verify deletion
            HttpResponseMessage getAfterDeleteResponse = await _client.GetAsync($"/evenementen/{eventId}");

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That(getAfterDeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
