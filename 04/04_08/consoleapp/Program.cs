int dag = int.Parse(Console.ReadLine());

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

if (dag >= 1 && dag <= 5)
{
    Console.WriteLine("werkdag");
}
else if (dag == 6 || dag == 7)
{
    Console.WriteLine("weekenddag");
}
