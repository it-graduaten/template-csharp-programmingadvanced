Console.Write("Voer je naam in: ");
string naam = Console.ReadLine();

WelkomstBoodschap(naam);

void WelkomstBoodschap(string naam)
{
    Console.WriteLine($"Welkom, {naam}!");
}
