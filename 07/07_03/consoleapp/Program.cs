Console.Write("Voer de productnaam in: ");
string productNaam = Console.ReadLine();

Console.Write("Voer de prijs per stuk in: ");
double prijsPerStuk = double.Parse(Console.ReadLine());

Console.Write("Voer het aantal in: ");
int aantal = int.Parse(Console.ReadLine());

double totaalPrijs = BerekenTotaalPrijs(productNaam, prijsPerStuk, aantal);

Console.WriteLine($"De totaalprijs is {totaalPrijs}.");

double BerekenTotaalPrijs(string productNaam, double prijsPerStuk, int aantal)
{
    return prijsPerStuk * aantal;
}
