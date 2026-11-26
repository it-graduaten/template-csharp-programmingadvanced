namespace EvenementApp;

public class InschrijvingService
{
    private readonly IInschrijvingRepository _repository;

    public InschrijvingService(IInschrijvingRepository repository)
    {
        _repository = repository;
    }

    public InschrijvingResultaat Beoordeel(int evenementId, int capaciteit, int aangevraagdAantal, bool heeftKortingscode)
    {
        if (evenementId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(evenementId));
        }

        if (capaciteit <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capaciteit));
        }

        if (aangevraagdAantal <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(aangevraagdAantal));
        }

        int huidigAantal = _repository.AantalInschrijvingenVoorEvenement(evenementId);

        if (huidigAantal < 0 || huidigAantal > capaciteit)
        {
            throw new InvalidOperationException("Het huidige aantal inschrijvingen is ongeldig.");
        }

        if (aangevraagdAantal > capaciteit - huidigAantal)
        {
            return new InschrijvingResultaat
            {
                Goedgekeurd = false,
                AantalToegekend = 0,
                TotaalPrijs = 0m
            };
        }

        decimal totaalPrijs = aangevraagdAantal * 30m;
        if (heeftKortingscode)
        {
            totaalPrijs *= 0.90m;
        }

        return new InschrijvingResultaat
        {
            Goedgekeurd = true,
            AantalToegekend = aangevraagdAantal,
            TotaalPrijs = totaalPrijs
        };
    }
}
