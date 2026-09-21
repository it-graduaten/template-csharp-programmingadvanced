List<string> namen = new List<string>();
int keuze;

do
{
    Console.WriteLine("\nKies een optie:");
    Console.WriteLine("1. Naam toevoegen");
    Console.WriteLine("2. Lijst tonen");
    Console.WriteLine("3. Naam zoeken");
    Console.WriteLine("4. Aantal namen bekijken");
    Console.WriteLine("5. Stoppen");
    Console.Write("Kies: ");
    keuze = int.Parse(Console.ReadLine());

    switch (keuze)
    {
        case 1:
            Console.Write("Voer de naam in: ");
            string nieuweNaam = Console.ReadLine();
            VoegNaamToe(namen, nieuweNaam);
            break;
        case 2:
            ToonNamen(namen);
            break;
        case 3:
            Console.Write("Voer de gezochte naam in: ");
            string gezochteNaam = Console.ReadLine();
            bool gevonden = ZoekNaam(namen, gezochteNaam);
            if (gevonden)
            {
                Console.WriteLine($"De naam '{gezochteNaam}' staat in de lijst.");
            }
            else
            {
                Console.WriteLine($"De naam '{gezochteNaam}' staat niet in de lijst.");
            }
            break;
        case 4:
            int aantal = TelNamen(namen);
            Console.WriteLine($"Er zijn {aantal} namen in de lijst.");
            break;
    }
} while (keuze != 5);

void VoegNaamToe(List<string> lijst, string naam)
{
    lijst.Add(naam);
    Console.WriteLine($"De naam '{naam}' is toegevoegd.");
}

void ToonNamen(List<string> lijst)
{
    Console.WriteLine("\nDe namen in de lijst:");
    for (int i = 0; i < lijst.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + lijst[i]);
    }
}

bool ZoekNaam(List<string> lijst, string naam)
{
    return lijst.Contains(naam);
}

int TelNamen(List<string> lijst)
{
    return lijst.Count;
}
