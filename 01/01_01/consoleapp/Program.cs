double prijs = double.Parse(Console.ReadLine());
double btw = double.Parse(Console.ReadLine());

double totaal = prijs + prijs / 100 * btw;

Console.WriteLine(totaal.ToString("N2"));
