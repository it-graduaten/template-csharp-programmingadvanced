List<string> boodschappen = new List<string>();

Console.Write("Geef product 1: ");
boodschappen.Add(Console.ReadLine());

Console.Write("Geef product 2: ");
boodschappen.Add(Console.ReadLine());

Console.Write("Geef product 3: ");
boodschappen.Add(Console.ReadLine());

Console.Write("Geef product 4: ");
boodschappen.Add(Console.ReadLine());

Console.Write("Geef product 5: ");
boodschappen.Add(Console.ReadLine());

Console.Write("Wil je een product verwijderen? (ja/nee): ");
string antwoord = Console.ReadLine().ToLower();

if (antwoord == "ja")
{
    Console.Write("Welk product wil je verwijderen? ");
    string product = Console.ReadLine();
    boodschappen.Remove(product);
}

Console.WriteLine($"Aantal producten: {boodschappen.Count}");

int i = 0;
while (i < boodschappen.Count)
{
    Console.WriteLine(boodschappen[i]);
    i++;
}
