int totaal = 0;

Console.WriteLine("Geef een getal (0 = stop):");
int getal = int.Parse(Console.ReadLine());

while (getal != 0)
{
    totaal += getal;

    Console.WriteLine("Geef een getal (0 = stop):");
    getal = int.Parse(Console.ReadLine());
}

Console.WriteLine($"Totaal: {totaal}");
