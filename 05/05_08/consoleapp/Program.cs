Console.WriteLine("Hoeveel producten wil je invoeren?");
int aantal = int.Parse(Console.ReadLine());

string[] productNamen = new string[aantal];
int[] prijzen = new int[aantal];

for (int i = 0; i < productNamen.Length; i++)
{
    Console.Write($"Geef naam product {i + 1}: ");
    productNamen[i] = Console.ReadLine();
    Console.Write($"Geef prijs van product {i + 1} in centen: ");
    prijzen[i] = int.Parse(Console.ReadLine());
}

int maxPrijs = prijzen[0];
int maxIndex = 0;

for (int i = 1; i < prijzen.Length; i++)
{
    if (prijzen[i] > maxPrijs)
    {
        maxPrijs = prijzen[i];
        maxIndex = i;
    }
}

Console.WriteLine($"Duurste product: {productNamen[maxIndex]} voor {maxPrijs} centen");
