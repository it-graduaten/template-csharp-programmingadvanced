List<string> kleuren = new List<string>();

Console.Write("Geef kleur 1: ");
kleuren.Add(Console.ReadLine());

Console.Write("Geef kleur 2: ");
kleuren.Add(Console.ReadLine());

Console.Write("Geef kleur 3: ");
kleuren.Add(Console.ReadLine());

Console.Write("Geef kleur 4: ");
kleuren.Add(Console.ReadLine());

Console.Write("Wil je een vijfde kleur toevoegen? (ja/nee): ");
string antwoord = Console.ReadLine().ToLower();

if (antwoord == "ja")
{
    Console.Write("Geef de vijfde kleur: ");
    kleuren.Add(Console.ReadLine());
}

Console.WriteLine($"Totaal aantal kleuren: {kleuren.Count}");

int i = 0;
while (i < kleuren.Count)
{
    Console.WriteLine(kleuren[i]);
    i++;
}
