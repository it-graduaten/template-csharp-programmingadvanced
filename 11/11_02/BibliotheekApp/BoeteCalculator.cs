namespace BibliotheekApp;

public class BoeteCalculator
{
    public decimal BerekenBoete(int dagenTeLaat, bool isNaslagwerk)
    {
        if (dagenTeLaat < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(dagenTeLaat));
        }

        decimal dagtarief = isNaslagwerk ? 1.25m : 0.50m;
        decimal boete = dagenTeLaat * dagtarief;

        if (boete > 20.00m)
        {
            return 20.00m;
        }

        return boete;
    }
}
