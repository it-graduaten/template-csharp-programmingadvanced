List<int> scores = new List<int>();

Console.WriteLine("Geef een score (0 = stop):");
int score = int.Parse(Console.ReadLine());

while (score != 0)
{
    scores.Add(score);

    Console.WriteLine("Geef een score (0 = stop):");
    score = int.Parse(Console.ReadLine());
}

int totaal = 0;

for (int i = 0; i < scores.Count; i++)
{
    totaal += scores[i];
}

int aantalScores = scores.Count;
double gemiddelde = (double)totaal / aantalScores;

int bovenGemiddelde = 0;

for (int i = 0; i < scores.Count; i++)
{
    if (scores[i] > gemiddelde)
    {
        bovenGemiddelde++;
    }
}

Console.WriteLine($"Aantal scores: {aantalScores}");
Console.WriteLine($"Gemiddelde: {gemiddelde}");
Console.WriteLine($"Scores boven gemiddelde: {bovenGemiddelde}");
