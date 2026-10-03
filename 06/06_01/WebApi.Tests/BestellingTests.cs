using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace WebApi.Tests;

public class BestellingTests
{
    private readonly WebApplicationFactory<Program> _factory;

    public BestellingTests()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [Test]
    public async Task GetAll_ReturnsAllBestellingen()
    {
        using var client = _factory.CreateWebApplicationFactory().CreateClient();

        var response = await client.GetAsync("/bestellingen");
        response.EnsureSuccessStatusCode();

        var bestellingen = await response.Content.ReadFromJsonAsync<List<object>>();

        Assert.That(bestellingen, Is.Not.Null);
        Assert.That(bestellingen!.Count, Is.EqualTo(5));
    }

    [Test]
    public async Task GetById_ReturnsBestelling()
    {
        using var client = _factory.CreateWebApplicationFactory().CreateClient();

        var response = await client.GetAsync("/bestellingen/1");
        response.EnsureSuccessStatusCode();

        var bestelling = await response.Content.ReadFromJsonAsync<object>();

        Assert.That(bestelling, Is.Not.Null);
    }

    [Test]
    public async Task GetById_NotFound()
    {
        using var client = _factory.CreateWebApplicationFactory().CreateClient();

        var response = await client.GetAsync("/bestellingen/999");

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
    }

    [Test]
    public async Task Create_CreatesBestellingAndReturnsCreated()
    {
        using var client = _factory.CreateWebApplicationFactory().CreateClient();

        var newBestelling = new
        {
            KlantId = 1,
            ProductNaam = "Nieuw Product",
            Aantal = 5,
            Besteldatum = DateTime.Now.ToString("yyyy-MM-dd")
        };

        var response = await client.PostAsJsonAsync("/bestellingen", newBestelling);
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));

        var createdBestelling = await response.Content.ReadFromJsonAsync<object>();
        Assert.That(createdBestelling, Is.Not.Null);
        Assert.That(createdBestelling!.Id, Is.GreaterThan(0));
    }

    [Test]
    public async Task Update_UpdatesBestellingAndReturnsNoContent()
    {
        using var client = _factory.CreateWebApplicationFactory().CreateClient();

        var updatedBestelling = new
        {
            Id = 1,
            KlantId = 2,
            ProductNaam = "Bijgewerkt Product",
            Aantal = 10,
            Besteldatum = DateTime.Now.ToString("yyyy-MM-dd")
        };

        var response = await client.PutAsJsonAsync("/bestellingen/1", updatedBestelling);
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));

        var getResponse = await client.GetAsync("/bestellingen/1");
        getResponse.EnsureSuccessStatusCode();

        var bestelling = await getResponse.Content.ReadFromJsonAsync<object>();
        Assert.That(bestelling, Is.Not.Null);
    }

    [Test]
    public async Task Delete_DeletesBestellingAndReturnsNoContent()
    {
        using var client = _factory.CreateWebApplicationFactory().CreateClient();

        var response = await client.DeleteAsync("/bestellingen/6");
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));

        var getResponse = await client.GetAsync("/bestellingen/6");
        Assert.That(getResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
    }
}
