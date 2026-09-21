Console.Write("Voor welke leeftijd vraag je het tarief? ");
int leeftijd = int.Parse(Console.ReadLine());

if (leeftijd >= 18)
{
    Console.WriteLine("Je bent meerderjarig.");
}
else
{
    Console.WriteLine("Je bent minderjarig.");
}
