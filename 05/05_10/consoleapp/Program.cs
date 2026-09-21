Console.WriteLine("Hoeveel scores wil je invoeren?");
int aantal = int.Parse(Console.ReadLine());

int[] scores = new int[aantal];

for (int i = 0; i < scores.Length; i++)
{
    Console.Write($"Geef score {i + 1}: ");
    scores[i] = int.Parse(Console.ReadLine());
}

int geslaagd = 0;
int gezakt = 0;

for (int i = 0; i < scores.Length; i++)
{
    if (scores[i] >= 10)
    {
        geslaagd++;
    }
    else
    {
        gezakt++;
    }
}

Console.WriteLine($"Geslaagd: {geslaagd}");
Console.WriteLine($"Gezakt: {gezakt}");
