int percentage;
string wiskunde;

Console.Write("Geef je gemiddelde percentage: ");
percentage = int.Parse(Console.ReadLine());

Console.Write("Heb je wiskunde gevolgd? (ja/nee): ");
wiskunde = Console.ReadLine().ToLower();

if (percentage >= 75 && wiskunde == "ja")
{
    Console.WriteLine("Wetenschap");
}
else if (percentage >= 75)
{
    Console.WriteLine("Letteren");
}
else if (percentage >= 60)
{
    Console.WriteLine("Techniek");
}
else
{
    Console.WriteLine("richtingskeuzebegeleiding");
}