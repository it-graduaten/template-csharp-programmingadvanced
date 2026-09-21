Console.WriteLine("Hoeveel lijnen wil je tonen?");
int aantal = int.Parse(Console.ReadLine());

for (int i = 1; i <= aantal; i++)
{
    Console.WriteLine($"Lijn {i}");
}
