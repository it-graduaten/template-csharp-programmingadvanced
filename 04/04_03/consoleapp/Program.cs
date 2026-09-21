string[] namen = new string[3];
int[] scores = new int[3];

Console.Write("Geef naam van student 1: ");
namen[0] = Console.ReadLine();
Console.Write("Geef score van student 1: ");
scores[0] = int.Parse(Console.ReadLine());

Console.Write("Geef naam van student 2: ");
namen[1] = Console.ReadLine();
Console.Write("Geef score van student 2: ");
scores[1] = int.Parse(Console.ReadLine());

Console.Write("Geef naam van student 3: ");
namen[2] = Console.ReadLine();
Console.Write("Geef score van student 3: ");
scores[2] = int.Parse(Console.ReadLine());

Console.WriteLine($"Student {namen[0]} heeft score {scores[0]}.");
Console.WriteLine($"Student {namen[1]} heeft score {scores[1]}.");
Console.WriteLine($"Student {namen[2]} heeft score {scores[2]}.");

double gemiddelde = (scores[0] + scores[1] + scores[2]) / 3.0;
Console.WriteLine($"Het gemiddelde is {gemiddelde}.");
