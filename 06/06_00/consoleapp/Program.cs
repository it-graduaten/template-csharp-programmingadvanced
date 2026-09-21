int totaal = 0;
int aantal = 0;

Console.WriteLine("Geef een getal (stop = einde):");
string invoer = Console.ReadLine();

while (invoer != "stop")
{
    if (int.TryParse(invoer, out int getal))
    {
        totaal += getal;
        aantal++;
    }

    Console.WriteLine("Geef een getal (stop = einde):");
    invoer = Console.ReadLine();
}

Console.WriteLine($"Totaal: {totaal}");
Console.WriteLine($"Aantal getallen: {aantal}");
