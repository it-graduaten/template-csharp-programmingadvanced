using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests;

public class OpleidingenApiTests
{
    [Test]
    public async Task GetCursussen_GeeftAlleenPubliekeCursusvelden()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        using HttpResponseMessage response = await client.GetAsync("/api/cursussen");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument document = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        JsonElement cursussen = document.RootElement;
        Assert.That(cursussen.ValueKind, Is.EqualTo(JsonValueKind.Array));
        Assert.That(cursussen.GetArrayLength(), Is.GreaterThanOrEqualTo(2));
        foreach (JsonElement cursus in cursussen.EnumerateArray())
        {
            string[] names = cursus.EnumerateObject().Select(property => property.Name).Order().ToArray();
            Assert.That(names, Is.EqualTo(new[] { "id", "prijs", "titel" }));
        }
    }

    [Test]
    public async Task GetDeelnemer_GeeftInschrijvingenMetBerekendeTotalenEnGeenPersoonsgegeven()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        using HttpResponseMessage response = await client.GetAsync("/api/deelnemers/1");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument document = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        JsonElement deelnemer = document.RootElement;
        string[] names = deelnemer.EnumerateObject().Select(property => property.Name).Order().ToArray();
        Assert.That(names, Is.EqualTo(new[] { "id", "inschrijvingen", "naam" }));
        Assert.That(deelnemer.GetProperty("inschrijvingen").GetArrayLength(), Is.GreaterThanOrEqualTo(1));
        using HttpResponseMessage cursusResponse = await client.GetAsync("/api/cursussen");
        using JsonDocument cursusDocument = JsonDocument.Parse(await cursusResponse.Content.ReadAsStringAsync());
        Dictionary<int, decimal> prijzen = cursusDocument.RootElement.EnumerateArray()
            .ToDictionary(cursus => cursus.GetProperty("id").GetInt32(), cursus => cursus.GetProperty("prijs").GetDecimal());
        AssertInschrijvingenCorrect(deelnemer.GetProperty("inschrijvingen"), prijzen);
    }

    [Test]
    public async Task PostInschrijving_WijzigtDeelnemerEnGeeftNieuweDtoTerug()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        const int deelnemerId = 1;
        const int cursusId = 1;
        using HttpResponseMessage cursusResponse = await client.GetAsync("/api/cursussen");
        using JsonDocument cursusDocument = JsonDocument.Parse(await cursusResponse.Content.ReadAsStringAsync());
        decimal cursusPrijs = cursusDocument.RootElement.EnumerateArray()
            .Single(cursus => cursus.GetProperty("id").GetInt32() == cursusId)
            .GetProperty("prijs").GetDecimal();
        const int aantalPlaatsen = 7;
        using HttpResponseMessage beforeResponse = await client.GetAsync($"/api/deelnemers/{deelnemerId}");
        Assert.That(beforeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument beforeDocument = JsonDocument.Parse(await beforeResponse.Content.ReadAsStringAsync());
        int beforeCount = beforeDocument.RootElement.GetProperty("inschrijvingen").GetArrayLength();

        using HttpResponseMessage postResponse = await client.PostAsJsonAsync(
            $"/api/deelnemers/{deelnemerId}/inschrijvingen",
            new { cursusId, aantalPlaatsen, id = -1, deelnemerId = 999, email = "private@example.com" });
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument postDocument = JsonDocument.Parse(await postResponse.Content.ReadAsStringAsync());
        JsonElement created = postDocument.RootElement;
        AssertInschrijvingDto(created);
        Assert.That(created.GetProperty("cursusId").GetInt32(), Is.EqualTo(cursusId));
        Assert.That(created.GetProperty("aantalPlaatsen").GetInt32(), Is.EqualTo(aantalPlaatsen));
        Assert.That(created.GetProperty("totaalPrijs").GetDecimal(), Is.EqualTo(aantalPlaatsen * cursusPrijs));
        string cursusTitel = created.GetProperty("cursusTitel").GetString()!;

        using HttpResponseMessage afterResponse = await client.GetAsync($"/api/deelnemers/{deelnemerId}");
        Assert.That(afterResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument afterDocument = JsonDocument.Parse(await afterResponse.Content.ReadAsStringAsync());
        JsonElement inschrijvingen = afterDocument.RootElement.GetProperty("inschrijvingen");
        Assert.That(inschrijvingen.GetArrayLength(), Is.EqualTo(beforeCount + 1));
        Assert.That(inschrijvingen.EnumerateArray().Any(item =>
            item.GetProperty("cursusId").GetInt32() == cursusId &&
            item.GetProperty("cursusTitel").GetString() == cursusTitel &&
            item.GetProperty("aantalPlaatsen").GetInt32() == aantalPlaatsen), Is.True);
    }

    [Test]
    public async Task PostInschrijving_OngeldigeAantalGeeftBadRequestEnLaatStateOngewijzigd()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        using HttpResponseMessage beforeResponse = await client.GetAsync("/api/deelnemers/1");
        Assert.That(beforeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument beforeDocument = JsonDocument.Parse(await beforeResponse.Content.ReadAsStringAsync());
        int beforeCount = beforeDocument.RootElement.GetProperty("inschrijvingen").GetArrayLength();

        using HttpResponseMessage postResponse = await client.PostAsJsonAsync(
            "/api/deelnemers/1/inschrijvingen", new { cursusId = 1, aantalPlaatsen = 0 });
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using HttpResponseMessage afterResponse = await client.GetAsync("/api/deelnemers/1");
        using JsonDocument afterDocument = JsonDocument.Parse(await afterResponse.Content.ReadAsStringAsync());
        Assert.That(afterDocument.RootElement.GetProperty("inschrijvingen").GetArrayLength(), Is.EqualTo(beforeCount));
    }

    [TestCase(2147483647, 1)]
    [TestCase(1, 2147483647)]
    public async Task PostInschrijving_OnbekendeDeelnemerOfCursusGeeftNotFound(int deelnemerId, int cursusId)
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        using HttpResponseMessage response = await client.PostAsJsonAsync(
            $"/api/deelnemers/{deelnemerId}/inschrijvingen", new { cursusId, aantalPlaatsen = 1 });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetOnbekendeDeelnemerGeeftNotFound()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        using HttpResponseMessage response = await client.GetAsync("/api/deelnemers/2147483647");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private static void AssertInschrijvingenCorrect(JsonElement inschrijvingen, IReadOnlyDictionary<int, decimal> prijzen)
    {
        foreach (JsonElement inschrijving in inschrijvingen.EnumerateArray())
        {
            AssertInschrijvingDto(inschrijving);
            Assert.That(inschrijving.GetProperty("cursusId").GetInt32(), Is.GreaterThan(0));
            Assert.That(inschrijving.GetProperty("cursusTitel").GetString(), Is.Not.Empty);
            int aantal = inschrijving.GetProperty("aantalPlaatsen").GetInt32();
            Assert.That(aantal, Is.GreaterThan(0));
            decimal verwachtePrijs = aantal * prijzen[inschrijving.GetProperty("cursusId").GetInt32()];
            Assert.That(inschrijving.GetProperty("totaalPrijs").GetDecimal(), Is.EqualTo(verwachtePrijs));
        }
    }

    private static void AssertInschrijvingDto(JsonElement inschrijving)
    {
        string[] names = inschrijving.EnumerateObject().Select(property => property.Name).Order().ToArray();
        Assert.That(names, Is.EqualTo(new[] { "aantalPlaatsen", "cursusId", "cursusTitel", "totaalPrijs" }));
        Assert.That(inschrijving.GetProperty("totaalPrijs").GetDecimal(), Is.GreaterThan(0));
    }
}
