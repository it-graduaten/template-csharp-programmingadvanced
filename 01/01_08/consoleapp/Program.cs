double bedragInEuro = double.Parse(Console.ReadLine());

double bedragInGbp = bedragInEuro * 1.08;
double bedragInUsd = bedragInEuro * 1.30;

Console.WriteLine(bedragInGbp.ToString("N2"));
Console.WriteLine(bedragInUsd.ToString("N2"));
