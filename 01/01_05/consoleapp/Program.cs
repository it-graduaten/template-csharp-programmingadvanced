double lengte = double.Parse(Console.ReadLine());
double polsOmtrek = double.Parse(Console.ReadLine());

double gewicht = (lengte + 4 * polsOmtrek - 100) / 2;

Console.WriteLine(gewicht.ToString("N2"));
