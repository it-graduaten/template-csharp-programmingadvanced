List<string> namen = new List<string>();
List<int> leeftijden = new List<int>();

Console.WriteLine("Geef de naam van een persoon (0 = einde):");
string naam = Console.ReadLine();

while (naam != "0")
{
    Console.WriteLine("Geef de leeftijd van {naam}:");
    int leeftijd = int.Parse(Console.ReadLine());

    if (leeftijd == 0)
        break;

    namen.Add(naam);
    leeftijden.Add(leeftijd);

    Console.WriteLine("Geef de naam van de volgende persoon (0 = einde):");
    naam = Console.ReadLine();
}

int totaalLeeftijd = 0;

for (int i = 0; i < leeftijden.Count; i++)
{
    totaalLeeftijd += leeftijden[i];
}

int aantalPersonen = leeftijden.Count;
double gemiddeldeLeeftijd = (double)totaalLeeftijd / aantalPersonen;

int boven30 = 0;

for (int i = 0; i < leeftijden.Count; i++)
{
    if (leeftijden[i] > 30)
    {
        boven30++;
    }
}

Console.WriteLine($"Aantal personen: {aantalPersonen}");
Console.WriteLine($"Gemiddelde leeftijd: {gemiddeldeLeeftijd}");
Console.WriteLine($"Personen ouder dan 30: {boven30}");
