Console.Write("Hoeveel getallen wil je invoeren? ");
int aantal = int.Parse(Console.ReadLine());

List<int> getallen = new List<int>();

for (int i = 0; i < aantal; i++)
{
    Console.Write($"Voer getal {i + 1} in: ");
    int getal = int.Parse(Console.ReadLine());
    getallen.Add(getal);
}

ToonLijst(getallen);

int maximum = VindMax(getallen);
int minimum = VindMin(getallen);
int totaal = BerekenTotaal(getallen);

Console.WriteLine($"Maximum: {maximum}");
Console.WriteLine($"Minimum: {minimum}");
Console.WriteLine($"Totaal: {totaal}");

void ToonLijst(List<int> lijst)
{
    Console.WriteLine("\nDe getallen in de lijst:");
    for (int i = 0; i < lijst.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + lijst[i]);
    }
}

int VindMax(List<int> lijst)
{
    int max = lijst[0];
    for (int i = 1; i < lijst.Count; i++)
    {
        if (lijst[i] > max)
        {
            max = lijst[i];
        }
    }
    return max;
}

int VindMin(List<int> lijst)
{
    int min = lijst[0];
    for (int i = 1; i < lijst.Count; i++)
    {
        if (lijst[i] < min)
        {
            min = lijst[i];
        }
    }
    return min;
}

int BerekenTotaal(List<int> lijst)
{
    int totaal = 0;
    for (int i = 0; i < lijst.Count; i++)
    {
        totaal += lijst[i];
    }
    return totaal;
}
