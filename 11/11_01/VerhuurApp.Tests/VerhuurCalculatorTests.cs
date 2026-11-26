using VerhuurApp;

namespace VerhuurApp.Tests;

public class VerhuurCalculatorTests
{
    [TestCase(12.50, 1, 12.50)]
    [TestCase(12.50, 4, 50.00)]
    [TestCase(0.00, 3, 0.00)]
    [TestCase(12.50, 0, 0.00)]
    [TestCase(7.25, 3, 21.75)]
    public void BerekenPrijs_GeldigeInvoer_GeeftProductVanPrijsEnDagen(decimal dagprijs, int dagen, decimal verwacht)
    {
        // Arrange
        var calculator = new VerhuurCalculator();

        // Act
        decimal resultaat = calculator.BerekenPrijs(dagprijs, dagen);

        // Assert
        Assert.That(resultaat, Is.EqualTo(verwacht));
    }

    [Test]
    public void BerekenPrijs_NegatieveDagprijs_GooitArgumentOutOfRangeException()
    {
        var calculator = new VerhuurCalculator();

        Assert.That(() => calculator.BerekenPrijs(-0.01m, 1), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void BerekenPrijs_NegatiefAantalDagen_GooitArgumentOutOfRangeException()
    {
        var calculator = new VerhuurCalculator();

        Assert.That(() => calculator.BerekenPrijs(12.50m, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}
