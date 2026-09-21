int aantalVol = int.Parse(Console.ReadLine());
int aantalKind = int.Parse(Console.ReadLine());

double totaal = aantalVol * 10 + aantalKind * 7.5;

Console.WriteLine(totaal.ToString("N2"));
