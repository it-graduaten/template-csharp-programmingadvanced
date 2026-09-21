Console.Write("Voor welk geslacht vraag je het tarief? ");
string geslacht = Console.ReadLine();

Console.Write("Voor welke leeftijd vraag je het tarief? ");
int leeftijd = int.Parse(Console.ReadLine());

if (leeftijd > 60)
{
    Console.WriteLine("Pensioen");
}
else if (leeftijd >= 18 && leeftijd <= 60)
{
    Console.WriteLine("Werkend");
}
else
{
    Console.WriteLine("Kind");
}
