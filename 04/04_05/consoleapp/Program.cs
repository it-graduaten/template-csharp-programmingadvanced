List<string> gestemden = new List<string>();

Console.Write("Hoeveel studenten gaan stemmen? ");
int aantal = int.Parse(Console.ReadLine());

int stemmenAnna = 0;
int stemmenBart = 0;

int i = 0;
while (i < aantal)
{
    Console.Write($"Naam van student {i + 1}: ");
    string naam = Console.ReadLine();
    gestemden.Add(naam);

    Console.Write("Voor welke kandidaat stem je? (Anna/Bart): ");
    string kandidaat = Console.ReadLine().ToLower();

    if (kandidaat == "anna")
    {
        stemmenAnna++;
    }
    else if (kandidaat == "bart")
    {
        stemmenBart++;
    }

    i++;
}

Console.WriteLine($"Totaal aantal stemmen: {aantal}");
Console.WriteLine($"Stemmen voor Anna: {stemmenAnna}");
Console.WriteLine($"Stemmen voor Bart: {stemmenBart}");

if (stemmenAnna > stemmenBart)
{
    Console.WriteLine("Anna heeft gewonnen!");
}
else if (stemmenBart > stemmenAnna)
{
    Console.WriteLine("Bart heeft gewonnen!");
}
else
{
    Console.WriteLine("Het is een gelijke stand!");
}
