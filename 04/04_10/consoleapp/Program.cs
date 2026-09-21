int[] scores = new int[5];

Console.Write("Geef score van Student A: ");
scores[0] = int.Parse(Console.ReadLine());

Console.Write("Geef score van Student B: ");
scores[1] = int.Parse(Console.ReadLine());

Console.Write("Geef score van Student C: ");
scores[2] = int.Parse(Console.ReadLine());

Console.Write("Geef score van Student D: ");
scores[3] = int.Parse(Console.ReadLine());

Console.Write("Geef score van Student E: ");
scores[4] = int.Parse(Console.ReadLine());

int hoogste = scores[0];
string hoogsteStudent = "Student A";

if (scores[1] > hoogste)
{
    hoogste = scores[1];
    hoogsteStudent = "Student B";
}
if (scores[2] > hoogste)
{
    hoogste = scores[2];
    hoogsteStudent = "Student C";
}
if (scores[3] > hoogste)
{
    hoogste = scores[3];
    hoogsteStudent = "Student D";
}
if (scores[4] > hoogste)
{
    hoogste = scores[4];
    hoogsteStudent = "Student E";
}

int laagste = scores[0];
string laagsteStudent = "Student A";

if (scores[1] < laagste)
{
    laagste = scores[1];
    laagsteStudent = "Student B";
}
if (scores[2] < laagste)
{
    laagste = scores[2];
    laagsteStudent = "Student C";
}
if (scores[3] < laagste)
{
    laagste = scores[3];
    laagsteStudent = "Student D";
}
if (scores[4] < laagste)
{
    laagste = scores[4];
    laagsteStudent = "Student E";
}

double gemiddelde = (scores[0] + scores[1] + scores[2] + scores[3] + scores[4]) / 5.0;

Console.WriteLine($"De hoogste score is {hoogste} van {hoogsteStudent}.");
Console.WriteLine($"De laagste score is {laagste} van {laagsteStudent}.");
Console.WriteLine($"Het gemiddelde is {gemiddelde}.");
