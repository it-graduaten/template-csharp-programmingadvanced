using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests;

public class UitleningenApiTests
{
    [Test]
    public async Task PostValideertDataEnMateriaal_MaaktUitleningMetGemapteMateriaalnaam()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();

        object[] ongeldigeInvoer =
        [
            new { materiaalId = 1, uitlener = "", aantalDagen = 1 },
            new { materiaalId = 1, uitlener = "A", aantalDagen = 1 },
            new { materiaalId = 1, uitlener = new string('u', 61), aantalDagen = 1 },
            new { materiaalId = 1, uitlener = "Naam", aantalDagen = 0 },
            new { materiaalId = 1, uitlener = "Naam", aantalDagen = 31 },
            new { materiaalId = 999, uitlener = "Naam", aantalDagen = 1 },
            new { materiaalId = 0, uitlener = "Naam", aantalDagen = 1 }
        ];
        foreach (object invoer in ongeldigeInvoer)
        {
            using HttpResponseMessage invalid = await client.PostAsJsonAsync("/api/uitleningen", invoer);
            Assert.That(invalid.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        using HttpResponseMessage firstCreate = await client.PostAsJsonAsync("/api/uitleningen", new
        {
            materiaalId = 1,
            uitlener = "AB",
            aantalDagen = 1
        });
        Assert.That(firstCreate.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument firstDocument = JsonDocument.Parse(await firstCreate.Content.ReadAsStringAsync());
        JsonElement first = firstDocument.RootElement;
        AssertFields(first, "aantalDagen", "id", "materiaalNaam", "uitlener");
        Assert.That(Property(first, "id").GetInt32(), Is.GreaterThan(0));
        Assert.That(Property(first, "materiaalNaam").GetString(), Is.EqualTo("Projector"));
        Assert.That(Property(first, "uitlener").GetString(), Is.EqualTo("AB"));
        Assert.That(Property(first, "aantalDagen").GetInt32(), Is.EqualTo(1));

        int firstId = Property(first, "id").GetInt32();
        using HttpResponseMessage firstGet = await client.GetAsync($"/api/uitleningen/{firstId}");
        Assert.That(firstGet.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument firstGetDocument = JsonDocument.Parse(await firstGet.Content.ReadAsStringAsync());
        Assert.That(firstGetDocument.RootElement.GetRawText(), Is.EqualTo(first.GetRawText()));

        using HttpResponseMessage secondCreate = await client.PostAsJsonAsync("/api/uitleningen", new
        {
            materiaalId = 2,
            uitlener = new string('U', 60),
            aantalDagen = 30
        });
        Assert.That(secondCreate.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument secondDocument = JsonDocument.Parse(await secondCreate.Content.ReadAsStringAsync());
        JsonElement second = secondDocument.RootElement;
        Assert.That(Property(second, "materiaalNaam").GetString(), Is.EqualTo("Microfoon"));
        Assert.That(Property(second, "uitlener").GetString(), Is.EqualTo(new string('U', 60)));
        Assert.That(Property(second, "aantalDagen").GetInt32(), Is.EqualTo(30));
        Assert.That(Property(second, "id").GetInt32(), Is.Not.EqualTo(firstId));

        using HttpResponseMessage missing = await client.GetAsync("/api/uitleningen/2147483647");
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
