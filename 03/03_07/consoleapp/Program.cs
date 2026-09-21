//Variabelen declareren
int pincode, bedrag, saldo = 500;

//Pincode inlezen
Console.Write("Geef je pincode (4 cijfers): ");
pincode = int.Parse(Console.ReadLine());

//Controle pincode
if (pincode == 1234)
{
    //Bedrag inlezen
    Console.Write("Geef het bedrag dat je wil opnemen: ");
    bedrag = int.Parse(Console.ReadLine());

    //Controle saldo
    if (bedrag > saldo)
    {
        Console.WriteLine("Onvoldoende saldo.");
    }
    else
    {
        saldo = saldo - bedrag;
        Console.WriteLine($"Uitbetaling van {bedrag}€ gaat door. Nieuw saldo: {saldo}€");
    }
}
else
{
    Console.WriteLine("Foute pincode.");
}