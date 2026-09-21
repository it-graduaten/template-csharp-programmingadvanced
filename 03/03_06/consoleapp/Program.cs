string zone;
int uren;
double bedrag;

Console.Write("Geef de zone (A, B of C): ");
zone = Console.ReadLine();

Console.Write("Geef het aantal geparkeerde uren: ");
uren = int.Parse(Console.ReadLine());

if (uren < 1)
{
    Console.WriteLine(0);
}
else
{
    switch (zone)
    {
        case "A":
            bedrag = uren * 2;
            break;
        case "B":
            bedrag = uren * 1.5;
            break;
        case "C":
            bedrag = uren * 1;
            break;
        default:
            Console.WriteLine("Ongeldige zone.");
            return;
    }

    if (bedrag > 10)
    {
        Console.WriteLine(10);
    }
    else
    {
        Console.WriteLine(bedrag);
    }
}