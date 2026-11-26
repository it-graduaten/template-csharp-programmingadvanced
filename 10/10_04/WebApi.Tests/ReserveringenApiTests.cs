using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests;

public class ReserveringenApiTests
{
    [Test]
    public async Task ReserveringenValiderenEnHoudenBeschikbaarheidEnTotaalprijsCorrectBij()
    {
        using WebApplicationFactory<Program> factory = new();
        using HttpClient client = factory.CreateClient();
        string customerOne = Guid.NewGuid().ToString("N").PadRight(60, 'K')[..60];

        using HttpResponseMessage createdResponse = await client.PostAsJsonAsync("/api/reserveringen", new
        {
            apparaatId = 1,
            klantnaam = customerOne,
            aantalDagen = 14,
            id = -1,
            beschikbaar = true,
            dagprijs = 0
        });
        Assert.That(createdResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument createdDocument = JsonDocument.Parse(await createdResponse.Content.ReadAsStringAsync());
        JsonElement created = createdDocument.RootElement;
        AssertDto(created, customerOne, 1, "3D-printer", 25m, 14, 350m);
        int firstId = Property(created, "id").GetInt32();

        using HttpResponseMessage getResponse = await client.GetAsync($"/api/reserveringen/{firstId}");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument getDocument = JsonDocument.Parse(await getResponse.Content.ReadAsStringAsync());
        Assert.That(getDocument.RootElement.GetRawText(), Is.EqualTo(created.GetRawText()));

        object[] invalidBodies =
        [
            new { apparaatId = 2, klantnaam = "", aantalDagen = 1 },
            new { apparaatId = 2, klantnaam = "A", aantalDagen = 1 },
            new { apparaatId = 2, klantnaam = new string('k', 61), aantalDagen = 1 },
            new { apparaatId = 2, klantnaam = "Klant", aantalDagen = 0 },
            new { apparaatId = 2, klantnaam = "Klant", aantalDagen = 15 },
            new { apparaatId = 0, klantnaam = "Klant", aantalDagen = 1 },
            new { apparaatId = 999, klantnaam = "Klant", aantalDagen = 1 }
        ];
        foreach (object body in invalidBodies)
        {
            using HttpResponseMessage invalid = await client.PostAsJsonAsync("/api/reserveringen", body);
            Assert.That(invalid.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        using HttpResponseMessage invalidPut = await client.PutAsJsonAsync($"/api/reserveringen/{firstId}", new
        {
            apparaatId = 2,
            klantnaam = "X",
            aantalDagen = 2
        });
        Assert.That(invalidPut.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        AssertDto(await GetDto(client, firstId), customerOne, 1, "3D-printer", 25m, 14, 350m);

        using HttpResponseMessage unknownDevicePut = await client.PutAsJsonAsync($"/api/reserveringen/{firstId}", new
        {
            apparaatId = 999,
            klantnaam = "Klant",
            aantalDagen = 2
        });
        Assert.That(unknownDevicePut.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        AssertDto(await GetDto(client, firstId), customerOne, 1, "3D-printer", 25m, 14, 350m);

        string updatedCustomer = "Gewijzigd " + Guid.NewGuid().ToString("N");
        using HttpResponseMessage sameDeviceUpdate = await client.PutAsJsonAsync($"/api/reserveringen/{firstId}", new
        {
            apparaatId = 1,
            klantnaam = updatedCustomer,
            aantalDagen = 2
        });
        Assert.That(sameDeviceUpdate.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        AssertDto(await GetDto(client, firstId), updatedCustomer, 1, "3D-printer", 25m, 2, 50m);

        using HttpResponseMessage transferResponse = await client.PutAsJsonAsync($"/api/reserveringen/{firstId}", new
        {
            apparaatId = 2,
            klantnaam = updatedCustomer,
            aantalDagen = 3
        });
        Assert.That(transferResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        JsonElement transferred = await GetDto(client, firstId);
        AssertDto(transferred, updatedCustomer, 2, "Lasersnijder", 40m, 3, 120m);
        Assert.That(Property(transferred, "id").GetInt32(), Is.EqualTo(firstId));

        string customerTwo = "AB";
        using HttpResponseMessage secondCreate = await client.PostAsJsonAsync("/api/reserveringen", new
        {
            apparaatId = 1,
            klantnaam = customerTwo,
            aantalDagen = 1
        });
        Assert.That(secondCreate.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        using JsonDocument secondDocument = JsonDocument.Parse(await secondCreate.Content.ReadAsStringAsync());
        JsonElement second = secondDocument.RootElement;
        AssertDto(second, customerTwo, 1, "3D-printer", 25m, 1, 25m);
        int secondId = Property(second, "id").GetInt32();
        Assert.That(secondId, Is.Not.EqualTo(firstId));

        using HttpResponseMessage unavailablePost = await client.PostAsJsonAsync("/api/reserveringen", new
        {
            apparaatId = 2,
            klantnaam = "Andere klant",
            aantalDagen = 1
        });
        Assert.That(unavailablePost.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using HttpResponseMessage unavailablePut = await client.PutAsJsonAsync($"/api/reserveringen/{firstId}", new
        {
            apparaatId = 1,
            klantnaam = "Mag niet worden opgeslagen",
            aantalDagen = 4
        });
        Assert.That(unavailablePut.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        AssertDto(await GetDto(client, firstId), updatedCustomer, 2, "Lasersnijder", 40m, 3, 120m);

        using HttpResponseMessage missingPut = await client.PutAsJsonAsync("/api/reserveringen/2147483647", new
        {
            apparaatId = 0,
            klantnaam = "X",
            aantalDagen = 0
        });
        Assert.That(missingPut.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        using HttpResponseMessage missingGet = await client.GetAsync("/api/reserveringen/2147483647");
        Assert.That(missingGet.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private static async Task<JsonElement> GetDto(HttpClient client, int id)
    {
        using HttpResponseMessage response = await client.GetAsync($"/api/reserveringen/{id}");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using JsonDocument document = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        return document.RootElement.Clone();
    }

    private static void AssertDto(JsonElement dto, string customer, int deviceId, string deviceName,
        decimal dailyPrice, int days, decimal totalPrice)
    {
        string[] names = dto.EnumerateObject().Select(property => property.Name.ToLowerInvariant()).Order().ToArray();
        Assert.That(names, Is.EqualTo(new[]
        {
            "aantalDagen", "apparaatId", "apparaatNaam", "dagprijs", "id", "klantnaam", "totaalPrijs"
        }.Select(name => name.ToLowerInvariant()).Order().ToArray()));
        Assert.That(Property(dto, "id").GetInt32(), Is.GreaterThan(0));
        Assert.That(Property(dto, "apparaatId").GetInt32(), Is.EqualTo(deviceId));
        Assert.That(Property(dto, "apparaatNaam").GetString(), Is.EqualTo(deviceName));
        Assert.That(Property(dto, "dagprijs").GetDecimal(), Is.EqualTo(dailyPrice));
        Assert.That(Property(dto, "klantnaam").GetString(), Is.EqualTo(customer));
        Assert.That(Property(dto, "aantalDagen").GetInt32(), Is.EqualTo(days));
        Assert.That(Property(dto, "totaalPrijs").GetDecimal(), Is.EqualTo(totalPrice));
        Assert.That(Property(dto, "totaalPrijs").GetDecimal(), Is.EqualTo(dailyPrice * days));
    }

    private static JsonElement Property(JsonElement element, string name) =>
        element.EnumerateObject().First(property => string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase)).Value;
}
