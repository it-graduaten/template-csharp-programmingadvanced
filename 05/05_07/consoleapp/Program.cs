Console.WriteLine("Hoeveel namen wil je invoeren?");
int aantal = int.Parse(Console.ReadLine());

string[] namen = new string[aantal];

for (int i = 0; i < namen.Length; i++)
{
    Console.Write($"Geef naam {i + 1}: ");
    namen[i] = Console.ReadLine();
}

Console.WriteLine();

for (int i = namen.Length - 1; i >= 0; i--)
{
    Console.WriteLine(namen[i]);
}
