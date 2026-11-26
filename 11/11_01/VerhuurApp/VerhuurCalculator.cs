namespace VerhuurApp;

public class VerhuurCalculator
{
    public decimal BerekenPrijs(decimal dagprijs, int aantalDagen)
    {
        if (dagprijs < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(dagprijs));
        }

        if (aantalDagen < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(aantalDagen));
        }

        return dagprijs * aantalDagen;
    }
}
