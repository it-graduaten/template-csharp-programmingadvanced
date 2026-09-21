Console.Write("Geef je gebruikersnaam: ");
string gebruikersnaam = Console.ReadLine();

Console.Write("Geef je wachtwoord: ");
string wachtwoord = Console.ReadLine();

if (gebruikersnaam == "admin" && wachtwoord == "geheim123")
{
    Console.WriteLine("Toegang toegestaan");
}
else
{
    Console.WriteLine("Toegang geweigerd.");
}
