Console.WriteLine("Geef een wachtwoord:");
string wachtwoord = Console.ReadLine();

while (wachtwoord.Length < 8)
{
    Console.WriteLine("Wachtwoord moet minstens 8 tekens lang zijn. Probeer opnieuw:");
    wachtwoord = Console.ReadLine();
}
