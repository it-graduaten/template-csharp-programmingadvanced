using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests;

public class TentoonstellingenApiTests
{
    [Test]
    public async Task PostValideertWriteDto_MaaktEenNietGepubliceerdeTentoonstellingEnGeeftDezeTerug()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        string token = Guid.NewGuid().ToString("N");

        object[] ongeldigeInvoer =
        [
            new { titel = "", beschrijving = "Tekst", maximaalAantalBezoekers = 1 },
            new { titel = "ab", beschrijving = "Tekst", maximaalAantalBezoekers = 1 },
            new { titel = new string('t', 81), beschrijving = "Tekst", maximaalAantalBezoekers = 1 },
            new { titel = "Geldig", beschrijving = "", maximaalAantalBezoekers = 1 },
            new { titel = "Geldig", beschrijving = new string('b', 301), maximaalAantalBezoekers = 1 },
            new { titel = "Geldig", beschrijving = "Tekst", maximaalAantalBezoekers = 0 },
            new { titel = "Geldig", beschrijving = "Tekst", maximaalAantalBezoekers = 5001 }
        ];

        foreach (object invoer in ongeldigeInvoer)
        {
            using HttpResponseMessage invalid = await client.PostAsJsonAsync("/api/tentoonstellingen", invoer);
            Assert.That(invalid.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        using HttpResponseMessage minimumValid = await client.PostAsJsonAsync("/api/tentoonstellingen", new
        {
            titel = "ABC",
            beschrijving = "x",
            maximaalAantalBezoekers = 1
        });
        Assert.That(minimumValid.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument minimumDocument = JsonDocument.Parse(await minimumValid.Content.ReadAsStringAsync());
        int minimumId = Property(minimumDocument.RootElement, "id").GetInt32();

        object geldigPayload = new
        {
            titel = "T" + token[..2],
            beschrijving = new string('b', 300),
            maximaalAantalBezoekers = 5000,
            id = -100,
            gepubliceerd = true
        };
        using HttpResponseMessage createResponse = await client.PostAsJsonAsync("/api/tentoonstellingen", geldigPayload);
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument createdDocument = JsonDocument.Parse(await createResponse.Content.ReadAsStringAsync());
        JsonElement created = createdDocument.RootElement;
        AssertFields(created, "beschrijving", "gepubliceerd", "id", "maximaalAantalBezoekers", "titel");
        int id = Property(created, "id").GetInt32();
        Assert.That(id, Is.GreaterThan(0));
        Assert.That(Property(created, "id").GetInt32(), Is.Not.EqualTo(-100));
        Assert.That(Property(created, "gepubliceerd").GetBoolean(), Is.False);
        Assert.That(Property(created, "titel").GetString(), Is.EqualTo("T" + token[..2]));
        Assert.That(Property(created, "beschrijving").GetString(), Is.EqualTo(new string('b', 300)));
        Assert.That(Property(created, "maximaalAantalBezoekers").GetInt32(), Is.EqualTo(5000));

        using HttpResponseMessage getResponse = await client.GetAsync($"/api/tentoonstellingen/{id}");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument getDocument = JsonDocument.Parse(await getResponse.Content.ReadAsStringAsync());
        Assert.That(getDocument.RootElement.GetRawText(), Is.EqualTo(created.GetRawText()));

        using HttpResponseMessage secondCreate = await client.PostAsJsonAsync("/api/tentoonstellingen", new
        {
            titel = new string('T', 80),
            beschrijving = "Tweede beschrijving",
            maximaalAantalBezoekers = 1
        });
        Assert.That(secondCreate.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument secondDocument = JsonDocument.Parse(await secondCreate.Content.ReadAsStringAsync());
        int secondId = Property(secondDocument.RootElement, "id").GetInt32();
        Assert.That(secondId, Is.GreaterThan(0));
        Assert.That(secondId, Is.Not.EqualTo(id));
        Assert.That(secondId, Is.Not.EqualTo(minimumId));

        using HttpResponseMessage missing = await client.GetAsync("/api/tentoonstellingen/2147483647");
        Assert.That(missing.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private static void AssertFields(JsonElement element, params string[] expected)
    {
        string[] names = element.EnumerateObject().Select(property => property.Name.ToLowerInvariant()).Order().ToArray();
        Assert.That(names, Is.EqualTo(expected.Select(name => name.ToLowerInvariant()).Order().ToArray()));
    }

    private static JsonElement Property(JsonElement element, string name) =>
        element.EnumerateObject().First(property => string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase)).Value;
}
