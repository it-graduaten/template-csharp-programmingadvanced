string letter;

Console.Write("Geef een letter: ");
letter = Console.ReadLine();

switch (letter.ToUpper())
{
    case "A":
    case "E":
    case "I":
    case "O":
    case "U":
        Console.WriteLine("Klinker");
        break;
    default:
        Console.WriteLine("Medeklinker");
        break;
}
