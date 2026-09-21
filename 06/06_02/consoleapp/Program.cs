Console.WriteLine("Geef een getal tussen 1 en 10:");
int getal = int.Parse(Console.ReadLine());

while (getal < 1 || getal > 10)
{
    Console.WriteLine("Ongeldig getal. Geef een getal tussen 1 en 10:");
    getal = int.Parse(Console.ReadLine());
}

Console.WriteLine($"Je hebt het getal {getal} ingevoerd.");