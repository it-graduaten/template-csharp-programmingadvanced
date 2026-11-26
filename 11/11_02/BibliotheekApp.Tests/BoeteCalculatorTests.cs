using BibliotheekApp;

namespace BibliotheekApp.Tests;

public class BoeteCalculatorTests
{
    [TestCase(0, false, 0.00)]
    [TestCase(3, false, 1.50)]
    [TestCase(3, true, 3.75)]
    [TestCase(39, false, 19.50)]
    [TestCase(40, false, 20.00)]
    [TestCase(15, true, 18.75)]
    [TestCase(16, true, 20.00)]
    [TestCase(50, false, 20.00)]
    [TestCase(50, true, 20.00)]
    public void BerekenBoete_GeldigeInvoer_BerekentDagprijsMetMaximum(int dagenTeLaat, bool isNaslagwerk, decimal verwacht)
    {
        // Arrange
        var calculator = new BoeteCalculator();

        // Act
        decimal resultaat = calculator.BerekenBoete(dagenTeLaat, isNaslagwerk);

        // Assert
        Assert.That(resultaat, Is.EqualTo(verwacht));
    }

    [Test]
    public void BerekenBoete_NegatiefAantalDagen_GooitArgumentOutOfRangeException()
    {
        var calculator = new BoeteCalculator();

        Assert.That(() => calculator.BerekenBoete(-1, false), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}
