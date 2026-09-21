int[] tickets = new int[3];

Console.Write("Geef aantal verkochte tickets voor voorstelling 1: ");
tickets[0] = int.Parse(Console.ReadLine());

Console.Write("Geef aantal verkochte tickets voor voorstelling 2: ");
tickets[1] = int.Parse(Console.ReadLine());

Console.Write("Geef aantal verkochte tickets voor voorstelling 3: ");
tickets[2] = int.Parse(Console.ReadLine());

int totaal = tickets[0] + tickets[1] + tickets[2];

int meeste = tickets[0];
int voorstellingMetMeeste = 1;

if (tickets[1] > meeste)
{
    meeste = tickets[1];
    voorstellingMetMeeste = 2;
}
if (tickets[2] > meeste)
{
    meeste = tickets[2];
    voorstellingMetMeeste = 3;
}

Console.WriteLine($"Totaal aantal verkochte tickets: {totaal}");
Console.WriteLine($"Voorstelling {voorstellingMetMeeste} heeft de meeste tickets verkocht met {meeste} tickets.");
