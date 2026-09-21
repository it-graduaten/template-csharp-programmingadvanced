//Variabelen declareren
int jaar;

//Jaar inlezen
Console.Write("Geef een jaartal: ");
jaar = int.Parse(Console.ReadLine());

//Berekeningen en afdrukken van resultaat
if (jaar % 400 == 0)
{
    Console.WriteLine("Schrikkeljaar");
}
else if (jaar % 100 == 0)
{
    Console.WriteLine("Geen schrikkeljaar");
}
else if (jaar % 4 == 0)
{
    Console.WriteLine("Schrikkeljaar");
}
else
{
    Console.WriteLine("Geen schrikkeljaar");
}