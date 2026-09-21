int[] getallen = new int[3];

Console.Write("Geef getal 1: ");
getallen[0] = int.Parse(Console.ReadLine());

Console.Write("Geef getal 2: ");
getallen[1] = int.Parse(Console.ReadLine());

Console.Write("Geef getal 3: ");
getallen[2] = int.Parse(Console.ReadLine());

int grootste = getallen[0];

if (getallen[1] > grootste)
{
    grootste = getallen[1];
}
if (getallen[2] > grootste)
{
    grootste = getallen[2];
}

Console.WriteLine($"Het grootste getal is {grootste}.");
