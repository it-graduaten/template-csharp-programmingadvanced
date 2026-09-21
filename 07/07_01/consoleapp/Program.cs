ToonMenu();

int keuze = int.Parse(Console.ReadLine());

if (keuze == 1 || keuze == 2 || keuze == 3)
{
    Console.Write("Voer het eerste getal in: ");
    int getal1 = int.Parse(Console.ReadLine());

    Console.Write("Voer het tweede getal in: ");
    int getal2 = int.Parse(Console.ReadLine());

    int resultaat;

    switch (keuze)
    {
        case 1:
            resultaat = getal1 + getal2;
            break;
        case 2:
            resultaat = getal1 - getal2;
            break;
        case 3:
            resultaat = getal1 * getal2;
            break;
        default:
            resultaat = 0;
            break;
    }

    Console.WriteLine($"Resultaat: {resultaat}");
}

void ToonMenu()
{
    Console.WriteLine("Kies een bewerking:");
    Console.WriteLine("1. Optellen");
    Console.WriteLine("2. Aftrekken");
    Console.WriteLine("3. Vermenigvuldigen");
    Console.Write("Keuze: ");
}