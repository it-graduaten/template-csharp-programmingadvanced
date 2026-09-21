int bedrag;
string lid;
double totaal;

Console.Write("Geef het aankoopbedrag: ");
bedrag = int.Parse(Console.ReadLine());

Console.Write("Ben je betalende lid? (ja/nee): ");
lid = Console.ReadLine().ToLower();

if (bedrag > 100 && lid == "ja")
{
    totaal = bedrag * 0.85;
}
else if (bedrag > 100)
{
    totaal = bedrag * 0.95;
}
else
{
    totaal = bedrag;
}

Console.WriteLine(totaal);