using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests;

public class BoekenApiTests
{
    [Test]
    public async Task GetBoeken_GeeftDtosZonderInterneVelden_EnGetPerIdGeeftHetzelfdeBoek()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();

        using HttpResponseMessage lijstResponse = await client.GetAsync("/api/boeken");
        Assert.That(lijstResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument lijstDocument = JsonDocument.Parse(await lijstResponse.Content.ReadAsStringAsync());
        JsonElement boeken = lijstDocument.RootElement;
        Assert.That(boeken.ValueKind, Is.EqualTo(JsonValueKind.Array));

        foreach (JsonElement boek in boeken.EnumerateArray())
        {
            AssertBoekDto(boek);
            int id = GetInt(boek, "id");

            using HttpResponseMessage detailResponse = await client.GetAsync($"/api/boeken/{id}");
            Assert.That(detailResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using JsonDocument detailDocument = JsonDocument.Parse(await detailResponse.Content.ReadAsStringAsync());
            JsonElement detail = detailDocument.RootElement;
            AssertBoekDto(detail);
            Assert.That(detail.GetRawText(), Is.EqualTo(boek.GetRawText()));
        }

        int onbekendId = 1;
        while (boeken.EnumerateArray().Any(boek => GetInt(boek, "id") == onbekendId))
        {
            onbekendId++;
        }

        using HttpResponseMessage onbekendResponse = await client.GetAsync($"/api/boeken/{onbekendId}");
        Assert.That(onbekendResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private static void AssertBoekDto(JsonElement boek)
    {
        Assert.That(boek.ValueKind, Is.EqualTo(JsonValueKind.Object));
        string[] namen = boek.EnumerateObject().Select(property => property.Name.ToLowerInvariant()).Order().ToArray();
        Assert.That(namen, Is.EqualTo(new[] { "auteur", "id", "isbn", "titel" }));
        Assert.That(GetInt(boek, "id"), Is.GreaterThan(0));
        Assert.That(GetString(boek, "titel"), Is.Not.Empty);
        Assert.That(GetString(boek, "auteur"), Is.Not.Empty);
        Assert.That(GetString(boek, "isbn"), Is.Not.Empty);
    }

    private static int GetInt(JsonElement element, string name) => element.GetProperty(name).GetInt32();
    private static string GetString(JsonElement element, string name) => element.GetProperty(name).GetString()!;
}
