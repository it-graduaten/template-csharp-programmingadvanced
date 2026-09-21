int grootste = int.MinValue;

Console.WriteLine("Geef een getal (stop = einde):");
string invoer = Console.ReadLine();

while (invoer != "stop")
{
    if (int.TryParse(invoer, out int getal))
    {
        if (getal > grootste)
        {
            grootste = getal;
        }
    }

    Console.WriteLine("Geef een getal (stop = einde):");
    invoer = Console.ReadLine();
}

Console.WriteLine($"Grootste getal: {grootste}");
