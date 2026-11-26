using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests;

public class ReservatiesApiTests
{
    [TestCase(1)]
    [TestCase(2)]
    public async Task GetOverzicht_GeeftPlatteDtoMetCorrecteBedragen(int id)
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        using HttpResponseMessage response = await client.GetAsync($"/api/reservaties/{id}/overzicht");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument document = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        JsonElement overzicht = document.RootElement;
        Assert.That(GetInt(overzicht, "id"), Is.EqualTo(id));
        Assert.That(GetString(overzicht, "klantNaam"), Is.Not.Empty);

        string[] overviewNames = overzicht.EnumerateObject().Select(property => property.Name).Order().ToArray();
        Assert.That(overviewNames, Is.EqualTo(new[] { "id", "klantNaam", "regels", "totaalPrijs" }));

        JsonElement regels = overzicht.GetProperty("regels");
        Assert.That(regels.ValueKind, Is.EqualTo(JsonValueKind.Array));
        decimal totaal = 0;
        foreach (JsonElement regel in regels.EnumerateArray())
        {
            string[] ruleNames = regel.EnumerateObject().Select(property => property.Name).Order().ToArray();
            Assert.That(ruleNames, Is.EqualTo(new[] { "aantal", "dagprijs", "materiaalNaam", "regelTotaal" }));
            decimal expectedRuleTotal = regel.GetProperty("aantal").GetInt32() * regel.GetProperty("dagprijs").GetDecimal();
            Assert.That(regel.GetProperty("regelTotaal").GetDecimal(), Is.EqualTo(expectedRuleTotal));
            totaal += expectedRuleTotal;
        }

        Assert.That(overzicht.GetProperty("totaalPrijs").GetDecimal(), Is.EqualTo(totaal));
    }

    [Test]
    public async Task GetOverzicht_OnbekendIdGeeftNotFound()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        using HttpResponseMessage response = await client.GetAsync("/api/reservaties/2147483647/overzicht");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private static int GetInt(JsonElement element, string name) => element.GetProperty(name).GetInt32();
    private static string GetString(JsonElement element, string name) => element.GetProperty(name).GetString()!;
}
