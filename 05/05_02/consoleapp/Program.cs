Console.WriteLine("Hoeveel scores wil je invoeren?");
int aantal = int.Parse(Console.ReadLine());

int[] scores = new int[aantal];

for (int i = 0; i < scores.Length; i++)
{
    Console.Write($"Geef score {i + 1}: ");
    scores[i] = int.Parse(Console.ReadLine());
}

int som = 0;

for (int i = 0; i < scores.Length; i++)
{
    som += scores[i];
}

Console.WriteLine($"Som: {som}");
