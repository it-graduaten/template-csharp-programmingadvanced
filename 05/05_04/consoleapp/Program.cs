Console.WriteLine("Hoeveel namen wil je invoeren?");
int aantal = int.Parse(Console.ReadLine());

string[] namen = new string[aantal];

for (int i = 0; i < namen.Length; i++)
{
    Console.Write($"Geef naam {i + 1}: ");
    namen[i] = Console.ReadLine();
}

Console.Write("Geef een letter: ");
char letter = char.Parse(Console.ReadLine());

int aantalBeginnendMet = 0;

for (int i = 0; i < namen.Length; i++)
{
    if (namen[i].Length > 0 && char.ToLower(namen[i][0]) == char.ToLower(letter))
    {
        aantalBeginnendMet++;
    }
}

Console.WriteLine($"Aantal namen dat begint met '{letter}': {aantalBeginnendMet}");
