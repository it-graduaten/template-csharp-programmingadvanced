int[] scores = new int[5];

Console.Write("Geef score van student 1: ");
scores[0] = int.Parse(Console.ReadLine());

Console.Write("Geef score van student 2: ");
scores[1] = int.Parse(Console.ReadLine());

Console.Write("Geef score van student 3: ");
scores[2] = int.Parse(Console.ReadLine());

Console.Write("Geef score van student 4: ");
scores[3] = int.Parse(Console.ReadLine());

Console.Write("Geef score van student 5: ");
scores[4] = int.Parse(Console.ReadLine());

double gemiddelde = (scores[0] + scores[1] + scores[2] + scores[3] + scores[4]) / 5.0;
Console.WriteLine($"Het gemiddelde is {gemiddelde}.");
