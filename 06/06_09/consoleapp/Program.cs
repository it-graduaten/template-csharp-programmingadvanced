Console.WriteLine("Hoeveel scores wil je invoeren?");
int aantal = int.Parse(Console.ReadLine());

int totaal = 0;

for (int i = 0; i < aantal; i++)
{
    Console.Write($"Geef score {i + 1}: ");
    int score = int.Parse(Console.ReadLine());

    while (score < 0 || score > 20)
    {
        Console.Write("Ongeldige score. Geef een score tussen 0 en 20: ");
        score = int.Parse(Console.ReadLine());
    }

    totaal += score;
}

double gemiddelde = (double)totaal / aantal;

Console.WriteLine($"Aantal scores: {aantal}");
Console.WriteLine($"Totaal: {totaal}");
Console.WriteLine($"Gemiddelde: {gemiddelde}");
