using EvenementApp;
using Moq;

namespace EvenementApp.Tests;

public class InschrijvingServiceTests
{
    [TestCase(0, 20, 2, false, true, 2, 60.00)]
    [TestCase(5, 20, 3, true, true, 3, 81.00)]
    [TestCase(18, 20, 3, false, false, 0, 0.00)]
    [TestCase(20, 20, 1, true, false, 0, 0.00)]
    [TestCase(7, 10, 3, false, true, 3, 90.00)]
    public void Beoordeel_GeldigeInvoer_BeoordeeltCapaciteitEnPrijs(
        int huidigAantal, int capaciteit, int aangevraagdAantal, bool kortingscode,
        bool verwachtGoedgekeurd, int verwachtAantal, decimal verwachtTotaal)
    {
        // Arrange
        const int evenementId = 314;
        var repository = new Mock<IInschrijvingRepository>();
        repository.Setup(r => r.AantalInschrijvingenVoorEvenement(evenementId)).Returns(huidigAantal);
        var service = new InschrijvingService(repository.Object);

        // Act
        InschrijvingResultaat resultaat = service.Beoordeel(evenementId, capaciteit, aangevraagdAantal, kortingscode);

        // Assert
        Assert.That(resultaat.Goedgekeurd, Is.EqualTo(verwachtGoedgekeurd));
        Assert.That(resultaat.AantalToegekend, Is.EqualTo(verwachtAantal));
        Assert.That(resultaat.TotaalPrijs, Is.EqualTo(verwachtTotaal));
        repository.Verify(r => r.AantalInschrijvingenVoorEvenement(evenementId), Times.Once);
        repository.VerifyNoOtherCalls();
    }

    [TestCase(0, 20, 1, "evenementId")]
    [TestCase(-1, 20, 1, "evenementId")]
    [TestCase(1, 0, 1, "capaciteit")]
    [TestCase(1, -1, 1, "capaciteit")]
    [TestCase(1, 20, 0, "aangevraagdAantal")]
    [TestCase(1, 20, -1, "aangevraagdAantal")]
    public void Beoordeel_OngeldigeArgumenten_GooitExceptionZonderRepositoryAanroep(
        int evenementId, int capaciteit, int aangevraagdAantal, string paramName)
    {
        // Arrange
        var repository = new Mock<IInschrijvingRepository>();
        var service = new InschrijvingService(repository.Object);

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => service.Beoordeel(evenementId, capaciteit, aangevraagdAantal, false));
        Assert.That(exception!.ParamName, Is.EqualTo(paramName));
        repository.Verify(r => r.AantalInschrijvingenVoorEvenement(It.IsAny<int>()), Times.Never);
        repository.VerifyNoOtherCalls();
    }

    [TestCase(-1)]
    [TestCase(21)]
    public void Beoordeel_OngeldigHuidigAantal_GooitInvalidOperationException(int huidigAantal)
    {
        // Arrange
        const int evenementId = 9;
        var repository = new Mock<IInschrijvingRepository>();
        repository.Setup(r => r.AantalInschrijvingenVoorEvenement(evenementId)).Returns(huidigAantal);
        var service = new InschrijvingService(repository.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => service.Beoordeel(evenementId, 20, 1, false));
        repository.Verify(r => r.AantalInschrijvingenVoorEvenement(evenementId), Times.Once);
        repository.VerifyNoOtherCalls();
    }
}
