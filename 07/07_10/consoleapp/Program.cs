int saldo = 1000;
int keuze;

do
{
    keuze = ToonMenu();

    switch (keuze)
    {
        case 1:
            ToonSaldo(saldo);
            break;
        case 2:
            Console.Write("Hoeveel geld wil je opnemen? ");
            int opnemenBedrag = int.Parse(Console.ReadLine());
            int nieuwSaldo = NeemOp(saldo, opnemenBedrag);
            if (nieuwSaldo < saldo)
            {
                saldo = nieuwSaldo;
                Console.WriteLine("Opname succesvol.");
            }
            else
            {
                Console.WriteLine("Onvoldoende saldo.");
            }
            break;
        case 3:
            Console.Write("Hoeveel geld wil je storten? ");
            int stortingsBedrag = int.Parse(Console.ReadLine());
            saldo = Stort(saldo, stortingsBedrag);
            Console.WriteLine("Storting succesvol.");
            break;
        case 4:
            Console.WriteLine("Bedankt en tot ziens!");
            break;
    }
} while (keuze != 4);

int ToonMenu()
{
    Console.WriteLine("\n--- Bankautomaat ---");
    Console.WriteLine("1. Saldo bekijken");
    Console.WriteLine("2. Geld opnemen");
    Console.WriteLine("3. Geld storten");
    Console.WriteLine("4. Stoppen");
    Console.Write("Kies een optie: ");
    return int.Parse(Console.ReadLine());
}

void ToonSaldo(int saldo)
{
    Console.WriteLine($"Het huidige saldo is {saldo} euro.");
}

int NeemOp(int saldo, int bedrag)
{
    if (bedrag > saldo)
    {
        Console.WriteLine("Kan niet meer opnemen dan er op de rekening staat.");
        return saldo;
    }
    return saldo - bedrag;
}

int Stort(int saldo, int bedrag)
{
    return saldo + bedrag;
}
