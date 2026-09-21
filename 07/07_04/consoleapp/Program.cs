int getal = ValideerGetal(1, 10);

Console.WriteLine($"Het geldige getal is {getal}.");

int ValideerGetal(int min, int max)
{
    int getal;
    string invoer;

    do
    {
        Console.Write($"Voer een getal tussen {min} en {max} in: ");
        invoer = Console.ReadLine();
    } while (!int.TryParse(invoer, out getal) || getal < min || getal > max);

    return getal;
}
