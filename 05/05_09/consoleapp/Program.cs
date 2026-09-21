Console.WriteLine("Geef een geheel getal: ");
int getal = int.Parse(Console.ReadLine());

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{getal} x {i} = {getal * i}");
}
