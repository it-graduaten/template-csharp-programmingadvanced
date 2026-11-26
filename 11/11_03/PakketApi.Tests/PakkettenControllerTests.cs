using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using PakketApi;

namespace PakketApi.Tests;

public class PakkettenControllerTests
{
    [Test]
    public async Task GetStatus_BestaandPakket_GeeftStatusEnVraagtOpgegevenIdEenmaalOp()
    {
        // Arrange
        const int pakketId = 73;
        var repository = new Mock<IPakketRepository>();
        repository.Setup(r => r.ZoekOpIdAsync(pakketId))
            .ReturnsAsync(new Pakket { Id = pakketId, Status = "In sorteercentrum" });
        var controller = new PakkettenController(repository.Object);

        // Act
        ActionResult<string> actieResultaat = await controller.GetStatus(pakketId);

        // Assert
        var ok = actieResultaat.Result as OkObjectResult;
        Assert.That(ok, Is.Not.Null);
        Assert.That(ok!.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        Assert.That(ok.Value, Is.EqualTo("In sorteercentrum"));
        repository.Verify(r => r.ZoekOpIdAsync(pakketId), Times.Once);
        repository.VerifyNoOtherCalls();
    }

    [Test]
    public async Task GetStatus_OnbekendPakket_GeeftNotFoundZonderBodyEnVraagtIdEenmaalOp()
    {
        // Arrange
        const int pakketId = 109;
        var repository = new Mock<IPakketRepository>();
        repository.Setup(r => r.ZoekOpIdAsync(pakketId)).ReturnsAsync((Pakket?)null);
        var controller = new PakkettenController(repository.Object);

        // Act
        ActionResult<string> actieResultaat = await controller.GetStatus(pakketId);

        // Assert
        var notFound = actieResultaat.Result as NotFoundResult;
        Assert.That(notFound, Is.Not.Null);
        Assert.That(notFound!.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
        repository.Verify(r => r.ZoekOpIdAsync(pakketId), Times.Once);
        repository.VerifyNoOtherCalls();
    }

    [Test]
    public async Task GetStatus_ViaDeVereisteHttpRoute_RouteertNaarRepository()
    {
        // Arrange
        const int pakketId = 241;
        var repository = new Mock<IPakketRepository>();
        repository.Setup(r => r.ZoekOpIdAsync(pakketId))
            .ReturnsAsync(new Pakket { Id = pakketId, Status = "Klaar voor bezorging" });
        using var factory = new PakketApiFactory(repository.Object);
        using HttpClient client = factory.CreateClient();

        // Act
        using HttpResponseMessage response = await client.GetAsync($"/api/pakketten/{pakketId}/status");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await response.Content.ReadAsStringAsync(), Is.EqualTo("Klaar voor bezorging"));
        repository.Verify(r => r.ZoekOpIdAsync(pakketId), Times.Once);
        repository.VerifyNoOtherCalls();
    }

    private sealed class PakketApiFactory : WebApplicationFactory<Program>
    {
        private readonly IPakketRepository _repository;

        public PakketApiFactory(IPakketRepository repository)
        {
            _repository = repository;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<IPakketRepository>();
                services.AddSingleton(_repository);
            });
        }
    }
}
