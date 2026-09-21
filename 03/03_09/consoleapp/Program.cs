//Variabelen declareren
int dag, uur, aantalPersonen;
double totaal, korting, resultaat;

//Gegevens inlezen
Console.Write("Geef de dag van de week (1-7): ");
dag = int.Parse(Console.ReadLine());

Console.Write("Geef het uur van aankomst: ");
uur = int.Parse(Console.ReadLine());

Console.Write("Geef het aantal personen: ");
aantalPersonen = int.Parse(Console.ReadLine());

Console.Write("Geef het totaalbedrag: ");
totaal = double.Parse(Console.ReadLine());

//Berekeningen en afdrukken van resultaat
korting = 0;

switch (dag)
{
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
        if (uur >= 11 && uur <= 14)
        {
            korting = 10;
        }
        break;
    case 6:
    case 7:
        if (uur >= 12 && uur <= 16)
        {
            korting = 15;
        }
        break;
}

if (aantalPersonen > 3)
{
    korting += 5;
}

resultaat = totaal - (totaal * (korting / 100));

Console.WriteLine($"Resultaat: {resultaat}");