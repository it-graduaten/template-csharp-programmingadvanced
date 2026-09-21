Console.Write("Hoeveel minuten wandel je per dag? ");
int minuten = int.Parse(Console.ReadLine());

if (minuten < 15)
{
    Console.WriteLine("Kort wandelen");
}
else if (minuten >= 15 && minuten <= 45)
{
    Console.WriteLine("Gemiddeld wandelen");
}
else
{
    Console.WriteLine("Lang wandelen");
}
