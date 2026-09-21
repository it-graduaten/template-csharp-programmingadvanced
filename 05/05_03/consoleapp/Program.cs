Console.WriteLine("Hoeveel getallen wil je invoeren?");
int aantal = int.Parse(Console.ReadLine());

int[] getallen = new int[aantal];

for (int i = 0; i < getallen.Length; i++)
{
    Console.Write($"Geef getal {i + 1}: ");
    getallen[i] = int.Parse(Console.ReadLine());
}

int totaal = 0;

for (int i = 0; i < getallen.Length; i++)
{
    totaal += getallen[i];
}

double gemiddelde = (double)totaal / getallen.Length;

Console.WriteLine($"Gemiddelde: {gemiddelde}");
