Console.Write("Voer de productnaam in: ");
string productNaam = Console.ReadLine();

Console.Write("Voer de prijs per stuk in: ");
double prijsPerStuk = double.Parse(Console.ReadLine());

Console.Write("Voer de hoeveelheid in: ");
int hoeveelheid = int.Parse(Console.ReadLine());

ToonBonnetje(productNaam, prijsPerStuk, hoeveelheid);

void ToonBonnetje(string productNaam, double prijsPerStuk, int hoeveelheid)
{
    double totaalPrijs = prijsPerStuk * hoeveelheid;

    Console.WriteLine("\n--- Bonnetje ---");
    Console.WriteLine($"Product: {productNaam}");
    Console.WriteLine($"Prijs per stuk: {prijsPerStuk}");
    Console.WriteLine($"Hoeveelheid: {hoeveelheid}");
    Console.WriteLine($"Totaalprijs: {totaalPrijs}");
}
