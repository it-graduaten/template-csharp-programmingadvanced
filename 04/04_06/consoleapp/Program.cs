string[] dagen = new string[7];

Console.Write("Geef dag 1: ");
dagen[0] = Console.ReadLine();

Console.Write("Geef dag 2: ");
dagen[1] = Console.ReadLine();

Console.Write("Geef dag 3: ");
dagen[2] = Console.ReadLine();

Console.Write("Geef dag 4: ");
dagen[3] = Console.ReadLine();

Console.Write("Geef dag 5: ");
dagen[4] = Console.ReadLine();

Console.Write("Geef dag 6: ");
dagen[5] = Console.ReadLine();

Console.Write("Geef dag 7: ");
dagen[6] = Console.ReadLine();

Console.WriteLine($"De eerste dag is {dagen[0]}.");
Console.WriteLine($"De laatste dag is {dagen[6]}.");
Console.WriteLine($"De dag op index 3 is {dagen[3]}.");
