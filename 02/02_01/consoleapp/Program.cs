Console.Write("Geef een getal: ");
int getal = int.Parse(Console.ReadLine());

if (getal > 0)
{
    Console.WriteLine("Het getal is positief");
}
else if (getal < 0)
{
    Console.WriteLine("Het getal is negatief");
}
else
{
    Console.WriteLine("Het getal is nul");
}
