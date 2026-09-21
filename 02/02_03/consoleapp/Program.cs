Console.Write("Geef de prijs van het product: ");
double prijs = double.Parse(Console.ReadLine());

Console.Write("Hoeveel stuks wil je kopen? ");
int aantal = int.Parse(Console.ReadLine());

double totalePrijs = prijs * aantal;

if (totalePrijs > 50)
{
    totalePrijs = totalePrijs - (totalePrijs * 10 / 100);
    Console.WriteLine(totalePrijs);
}
else
{
    Console.WriteLine("Geen korting");
    Console.WriteLine(totalePrijs);
}
