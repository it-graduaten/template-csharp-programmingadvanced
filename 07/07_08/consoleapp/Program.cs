Console.Write("Hoeveel scores wil je invoeren? ");
int aantal = int.Parse(Console.ReadLine());

List<int> scores = new List<int>();

for (int i = 0; i < aantal; i++)
{
    Console.Write($"Voer score {i + 1} in: ");
    int score = int.Parse(Console.ReadLine());
    scores.Add(score);
}

double gemiddelde = BerekenGemiddelde(scores);

Console.WriteLine($"De gemiddelde score is {gemiddelde}.");

double BerekenGemiddelde(List<int> scores)
{
    int totaal = 0;
    for (int i = 0; i < scores.Count; i++)
    {
        totaal += scores[i];
    }
    return (double)totaal / scores.Count;
}
