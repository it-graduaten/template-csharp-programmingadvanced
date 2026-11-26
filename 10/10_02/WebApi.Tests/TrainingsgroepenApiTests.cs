using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests;

public class TrainingsgroepenApiTests
{
    [Test]
    public async Task PutValideertEnWijzigtAlleenWriteDtoVelden()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();

        using HttpResponseMessage initialResponse = await client.GetAsync("/api/trainingsgroepen/1");
        Assert.That(initialResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument initialDocument = JsonDocument.Parse(await initialResponse.Content.ReadAsStringAsync());
        JsonElement initial = initialDocument.RootElement;
        AssertFields(initial, "actief", "dag", "id", "maximumLeden", "naam");
        Assert.That(Property(initial, "id").GetInt32(), Is.EqualTo(1));
        Assert.That(Property(initial, "naam").GetString(), Is.EqualTo("Junioren"));
        Assert.That(Property(initial, "dag").GetString(), Is.EqualTo("maandag"));
        Assert.That(Property(initial, "maximumLeden").GetInt32(), Is.EqualTo(20));
        Assert.That(Property(initial, "actief").GetBoolean(), Is.True);

        object[] ongeldigeInvoer =
        [
            new { naam = "", dag = "maandag", maximumLeden = 20 },
            new { naam = "A", dag = "maandag", maximumLeden = 20 },
            new { naam = new string('n', 61), dag = "maandag", maximumLeden = 20 },
            new { naam = "Geldig", dag = "", maximumLeden = 20 },
            new { naam = "Geldig", dag = "x", maximumLeden = 20 },
            new { naam = "Geldig", dag = new string('d', 16), maximumLeden = 20 },
            new { naam = "Geldig", dag = "maandag", maximumLeden = 0 },
            new { naam = "Geldig", dag = "maandag", maximumLeden = 81 }
        ];
        foreach (object invoer in ongeldigeInvoer)
        {
            using HttpResponseMessage invalid = await client.PutAsJsonAsync("/api/trainingsgroepen/1", invoer);
            Assert.That(invalid.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        using HttpResponseMessage unchangedResponse = await client.GetAsync("/api/trainingsgroepen/1");
        Assert.That(unchangedResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument unchangedDocument = JsonDocument.Parse(await unchangedResponse.Content.ReadAsStringAsync());
        Assert.That(unchangedDocument.RootElement.GetRawText(), Is.EqualTo(initial.GetRawText()));

        string name = Guid.NewGuid().ToString("N").PadRight(60, 'N')[..60];
        string day = new string('d', 15);
        using HttpResponseMessage updateResponse = await client.PutAsJsonAsync("/api/trainingsgroepen/1", new
        {
            naam = name,
            dag = day,
            maximumLeden = 80,
            id = 999,
            actief = false
        });
        Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

        using HttpResponseMessage updatedResponse = await client.GetAsync("/api/trainingsgroepen/1");
        Assert.That(updatedResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument updatedDocument = JsonDocument.Parse(await updatedResponse.Content.ReadAsStringAsync());
        JsonElement updated = updatedDocument.RootElement;
        Assert.That(Property(updated, "id").GetInt32(), Is.EqualTo(1));
        Assert.That(Property(updated, "naam").GetString(), Is.EqualTo(name));
        Assert.That(Property(updated, "dag").GetString(), Is.EqualTo(day));
        Assert.That(Property(updated, "maximumLeden").GetInt32(), Is.EqualTo(80));
        Assert.That(Property(updated, "actief").GetBoolean(), Is.True);

        using HttpResponseMessage minimumUpdate = await client.PutAsJsonAsync("/api/trainingsgroepen/1", new
        {
            naam = "AB",
            dag = "di",
            maximumLeden = 1
        });
        Assert.That(minimumUpdate.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        using HttpResponseMessage minimumRead = await client.GetAsync("/api/trainingsgroepen/1");
        Assert.That(minimumRead.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument minimumDocument = JsonDocument.Parse(await minimumRead.Content.ReadAsStringAsync());
        Assert.That(Property(minimumDocument.RootElement, "naam").GetString(), Is.EqualTo("AB"));
        Assert.That(Property(minimumDocument.RootElement, "dag").GetString(), Is.EqualTo("di"));
        Assert.That(Property(minimumDocument.RootElement, "maximumLeden").GetInt32(), Is.EqualTo(1));
        Assert.That(Property(minimumDocument.RootElement, "actief").GetBoolean(), Is.True);

        using HttpResponseMessage missingGet = await client.GetAsync("/api/trainingsgroepen/2147483647");
        Assert.That(missingGet.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        using HttpResponseMessage missingPut = await client.PutAsJsonAsync("/api/trainingsgroepen/2147483647", new
        {
            naam = "Andere groep",
            dag = "vrijdag",
            maximumLeden = 10
        });
        Assert.That(missingPut.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private static void AssertFields(JsonElement element, params string[] expected)
    {
        string[] names = element.EnumerateObject().Select(property => property.Name.ToLowerInvariant()).Order().ToArray();
        Assert.That(names, Is.EqualTo(expected.Select(name => name.ToLowerInvariant()).Order().ToArray()));
    }

    private static JsonElement Property(JsonElement element, string name) =>
        element.EnumerateObject().First(property => string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase)).Value;
}
