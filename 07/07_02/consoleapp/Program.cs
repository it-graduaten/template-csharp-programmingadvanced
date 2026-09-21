Console.Write("Voer het eerste getal in: ");
int getal1 = int.Parse(Console.ReadLine());

Console.Write("Voer het tweede getal in: ");
int getal2 = int.Parse(Console.ReadLine());

int som = BerekenSom(getal1, getal2);

Console.WriteLine($"De som is {som}.");

int BerekenSom(int a, int b)
{
    return a + b;
}
