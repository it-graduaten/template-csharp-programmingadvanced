//Variabelen declareren
string email;
bool geldig = true;

//Email inlezen
Console.Write("Geef een e-mail adres: ");
email = Console.ReadLine();

//Controle op lengte
if (email.Length < 5)
{
    Console.WriteLine("Ongeldig e-mailadres. Te kort.");
    geldig = false;
}

//Controle op @
if (geldig && !email.Contains("@"))
{
    Console.WriteLine("Ongeldig e-mailadres. Geen @ gevonden.");
    geldig = false;
}

//Controle op punt na @
if (geldig)
{
    int indexAan = email.IndexOf("@");
    string naAan = email.Substring(indexAan + 1);
    
    if (!naAan.Contains("."))
    {
        Console.WriteLine("Ongeldig e-mailadres. Geen punt na @ gevonden.");
        geldig = false;
    }
}

//Controle op domeinextensie
if (geldig)
{
    string extensie = "";
    if (email.EndsWith(".be"))
    {
        extensie = ".be";
    }
    else if (email.EndsWith(".nl"))
    {
        extensie = ".nl";
    }
    else if (email.EndsWith(".com"))
    {
        extensie = ".com";
    }
    else if (email.EndsWith(".org"))
    {
        extensie = ".org";
    }
    else
    {
        extensie = "ongeldig";
    }

    switch (extensie)
    {
        case ".be":
        case ".nl":
        case ".com":
        case ".org":
            Console.WriteLine("Geldig e-mailadres");
            break;
        default:
            Console.WriteLine("Ongeldige e-mail extensie.");
            break;
    }
}