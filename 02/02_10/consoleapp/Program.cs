Console.Write("Voor welke leeftijd vraag je het tarief? ");
int leeftijd = int.Parse(Console.ReadLine());

if (leeftijd < 12)
{
    Console.WriteLine("7 euro");
}
else if (leeftijd >= 12 && leeftijd <= 65)
{
    Console.WriteLine("12 euro");
}
else
{
    Console.WriteLine("9 euro");
}
