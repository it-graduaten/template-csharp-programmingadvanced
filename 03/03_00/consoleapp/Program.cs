int leeftijd, dag, bedrag;

Console.Write("Geef je leeftijd: ");
leeftijd = int.Parse(Console.ReadLine());

Console.Write("Geef de dag van de week (1-7): ");
dag = int.Parse(Console.ReadLine());

if (leeftijd < 12)
{
    bedrag = 7;
}
else if (leeftijd <= 65)
{
    bedrag = 12;
}
else
{
    bedrag = 9;
}

if (dag == 2)
{
    bedrag = bedrag - 2;
}

Console.WriteLine(bedrag + " euro");