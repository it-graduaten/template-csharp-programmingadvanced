//Variabelen declareren
int dag;

//Getal inlezen
Console.Write("Geef een getal tussen 1 en 7: ");
dag = int.Parse(Console.ReadLine());

//Berekeningen en afdrukken van resultaat
switch (dag)
{
    case 1:
        Console.WriteLine("maandag");
        break;
    case 2:
        Console.WriteLine("dinsdag");
        break;
    case 3:
        Console.WriteLine("woensdag");
        break;
    case 4:
        Console.WriteLine("donderdag");
        break;
    case 5:
        Console.WriteLine("vrijdag");
        break;
    case 6:
        Console.WriteLine("zaterdag");
        break;
    case 7:
        Console.WriteLine("zondag");
        break;
        default:
            Console.WriteLine("Ongeldige dag");
            break;
}
