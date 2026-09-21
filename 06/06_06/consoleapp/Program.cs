int aantalWoorden = 0;

Console.WriteLine("Geef een woord (stop = einde):");
string woord = Console.ReadLine();

while (woord != "stop")
{
    aantalWoorden++;

    Console.WriteLine("Geef een woord (stop = einde):");
    woord = Console.ReadLine();
}

Console.WriteLine($"Aantal woorden: {aantalWoorden}");
