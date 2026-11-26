namespace WebApi.Models;

public static class OpleidingsData
{
    public static List<Cursus> Cursussen { get; } =
    [
        new Cursus { Id = 1, Titel = "C# Basis", Prijs = 120m, InternCommentaar = "Interne cursus" },
        new Cursus { Id = 2, Titel = "Web API's", Prijs = 180m, InternCommentaar = "Nieuwe editie" }
    ];

    public static List<Deelnemer> Deelnemers { get; } = MaakDeelnemers();

    private static List<Deelnemer> MaakDeelnemers()
    {
        Cursus basis = Cursussen[0];
        Cursus api = Cursussen[1];

        return
        [
            new Deelnemer
            {
                Id = 1,
                Naam = "Noor",
                Email = "noor@example.com",
                Inschrijvingen =
                [
                    new Inschrijving { Id = 1, DeelnemerId = 1, CursusId = basis.Id, Cursus = basis, AantalPlaatsen = 1 },
                    new Inschrijving { Id = 2, DeelnemerId = 1, CursusId = api.Id, Cursus = api, AantalPlaatsen = 2 }
                ]
            },
            new Deelnemer
            {
                Id = 2,
                Naam = "Sam",
                Email = "sam@example.com",
                Inschrijvingen =
                [
                    new Inschrijving { Id = 3, DeelnemerId = 2, CursusId = basis.Id, Cursus = basis, AantalPlaatsen = 1 }
                ]
            }
        ];
    }
}
