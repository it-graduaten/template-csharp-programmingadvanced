using WebApi.Models;

namespace WebApi.Repositories;

public class InMemoryEvenementRepository : IEvenementRepository
{
    private List<Evenement> evenementen = new()
    {
        new Evenement { Id = 1, Naam = "Summer Music Festival", Locatie = "Antwerpen", Datum = "15-07-2026", MaxDeelnemers = 5000, GeregistreerdeDeelnemers = 3200 },
        new Evenement { Id = 2, Naam = "Culinaire Dagen", Locatie = "Brugge", Datum = "22-08-2026", MaxDeelnemers = 200, GeregistreerdeDeelnemers = 145 },
        new Evenement { Id = 3, Naam = "Tech Conference", Locatie = "Gent", Datum = "10-09-2026", MaxDeelnemers = 300, GeregistreerdeDeelnemers = 300 }
    };

    public List<Evenement> GetAll()
    {
        return evenementen;
    }

    public Evenement? GetById(int id)
    {
        return evenementen.FirstOrDefault(e => e.Id == id);
    }

    public List<Evenement>? GetByLocatie(string locatie)
    {
        var gevondenEvenementen = evenementen
            .Where(e => e.Locatie.ToLower() == locatie.ToLower())
            .ToList();

        if (gevondenEvenementen.Count == 0)
        {
            return null;
        }

        return gevondenEvenementen;
    }

    public Evenement Create(Evenement evenement)
    {
        int nieuweId = evenementen.Max(e => e.Id) + 1;
        evenement.Id = nieuweId;
        evenementen.Add(evenement);
        return evenement;
    }

    public void Update(int id, Evenement evenement)
    {
        var bestaandeEvenement = evenementen.FirstOrDefault(e => e.Id == id);

        if (bestaandeEvenement != null)
        {
            bestaandeEvenement.Id = evenement.Id;
            bestaandeEvenement.Naam = evenement.Naam;
            bestaandeEvenement.Locatie = evenement.Locatie;
            bestaandeEvenement.Datum = evenement.Datum;
            bestaandeEvenement.MaxDeelnemers = evenement.MaxDeelnemers;
            bestaandeEvenement.GeregistreerdeDeelnemers = evenement.GeregistreerdeDeelnemers;
        }
    }

    public void Delete(int id)
    {
        var evenement = evenementen.FirstOrDefault(e => e.Id == id);

        if (evenement != null)
        {
            evenementen.Remove(evenement);
        }
    }
}
