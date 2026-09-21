double afstand = double.Parse(Console.ReadLine());
double prijsPerLiter = double.Parse(Console.ReadLine());

double liter = afstand / 100 * 6.5;
double totaal = liter * prijsPerLiter;

Console.WriteLine(liter.ToString("N2"));
Console.WriteLine(totaal.ToString("N2"));
