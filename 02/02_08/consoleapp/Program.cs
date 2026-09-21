Console.Write("Geef je saldo: ");
double saldo = double.Parse(Console.ReadLine());

if (saldo > 1000)
{
    Console.WriteLine("Goed sparen!");
}
else if (saldo >= 500 && saldo <= 1000)
{
    Console.WriteLine("Bovengemiddeld");
}
else
{
    Console.WriteLine("Lager dan gemiddeld.");
}
