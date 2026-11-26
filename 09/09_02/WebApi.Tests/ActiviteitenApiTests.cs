using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests;

public class ActiviteitenApiTests
{
    [Test]
    public async Task PostMaaktActiviteit_AanvaardtAlleenWriteDtoVelden_EnIsDaarnaOpvraagbaar()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        string token = Guid.NewGuid().ToString("N");
        object payload = new
        {
            naam = "Activiteit " + token,
            beschrijving = "Beschrijving " + token,
            maximumDeelnemers = 17,
            id = -500,
            goedgekeurd = true
        };

        using HttpResponseMessage createResponse = await client.PostAsJsonAsync("/api/activiteiten", payload);
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument createdDocument = JsonDocument.Parse(await createResponse.Content.ReadAsStringAsync());
        JsonElement created = createdDocument.RootElement;
        AssertActiviteitFields(created);
        int id = created.GetProperty("id").GetInt32();
        Assert.That(id, Is.GreaterThan(0));
        Assert.That(id, Is.Not.EqualTo(-500));
        Assert.That(created.GetProperty("goedgekeurd").GetBoolean(), Is.False);
        Assert.That(created.GetProperty("naam").GetString(), Is.EqualTo("Activiteit " + token));
        Assert.That(created.GetProperty("beschrijving").GetString(), Is.EqualTo("Beschrijving " + token));
        Assert.That(created.GetProperty("maximumDeelnemers").GetInt32(), Is.EqualTo(17));

        using HttpResponseMessage getResponse = await client.GetAsync($"/api/activiteiten/{id}");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument getDocument = JsonDocument.Parse(await getResponse.Content.ReadAsStringAsync());
        Assert.That(getDocument.RootElement.GetRawText(), Is.EqualTo(created.GetRawText()));

        using HttpResponseMessage secondCreateResponse = await client.PostAsJsonAsync("/api/activiteiten", new
        {
            naam = "Tweede activiteit " + token,
            beschrijving = "Tweede beschrijving " + token,
            maximumDeelnemers = 1
        });
        Assert.That(secondCreateResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument secondCreatedDocument = JsonDocument.Parse(await secondCreateResponse.Content.ReadAsStringAsync());
        int secondId = secondCreatedDocument.RootElement.GetProperty("id").GetInt32();
        Assert.That(secondId, Is.GreaterThan(0));
        Assert.That(secondId, Is.Not.EqualTo(id));

        using HttpResponseMessage missingResponse = await client.GetAsync("/api/activiteiten/2147483647");
        Assert.That(missingResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [TestCase("", "Inhoud", 1)]
    [TestCase("Naam", "   ", 1)]
    [TestCase("Naam", "Inhoud", 0)]
    [TestCase("Naam", "Inhoud", -1)]
    public async Task PostMetOngeldigeInvoer_GeeftBadRequest(string naam, string beschrijving, int maximumDeelnemers)
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        using HttpResponseMessage response = await client.PostAsJsonAsync("/api/activiteiten", new
        {
            naam,
            beschrijving,
            maximumDeelnemers
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    private static void AssertActiviteitFields(JsonElement activiteit)
    {
        string[] names = activiteit.EnumerateObject().Select(property => property.Name).Order().ToArray();
        Assert.That(names, Is.EqualTo(new[] { "beschrijving", "goedgekeurd", "id", "maximumDeelnemers", "naam" }));
    }
}
