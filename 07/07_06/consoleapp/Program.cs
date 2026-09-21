Console.Write("Voer een getal in: ");
int getal = int.Parse(Console.ReadLine());

bool isEven = IsEven(getal);

if (isEven)
{
    Console.WriteLine($"{getal} is even.");
}
else
{
    Console.WriteLine($"{getal} is oneven.");
}

bool IsEven(int getal)
{
    return getal % 2 == 0;
}
