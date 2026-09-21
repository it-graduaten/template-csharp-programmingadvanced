//Variabelen declareren
int leeftijd;
string geslacht, begeleiding;

//Leeftijd en geslacht inlezen
Console.Write("Geef je leeftijd: ");
leeftijd = int.Parse(Console.ReadLine());

Console.Write("Geef je geslacht (M of V): ");
geslacht = Console.ReadLine();

//Berekeningen en afdrukken van resultaat
if (leeftijd < 10)
{
    Console.WriteLine("Toegang geweigerd");
}
else if (leeftijd >= 10 && leeftijd <= 17)
{
    Console.Write("Ben je vergezeld van een volwassene? (ja/neen): ");
    begeleiding = Console.ReadLine().ToLower();
    
    if (begeleiding == "ja")
    {
        Console.WriteLine("Toegang toegestaan");
    }
    else
    {
        Console.WriteLine("Toegang geweigerd");
    }
}
else
{
    Console.WriteLine("Toegang toegestaan");
}