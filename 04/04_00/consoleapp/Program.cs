int[] afwezigen = new int[3];

Console.Write("Geef het aantal afwezigen voor les 1: ");
afwezigen[0] = int.Parse(Console.ReadLine());

Console.Write("Geef het aantal afwezigen voor les 2: ");
afwezigen[1] = int.Parse(Console.ReadLine());

Console.Write("Geef het aantal afwezigen voor les 3: ");
afwezigen[2] = int.Parse(Console.ReadLine());

int totaal = afwezigen[0] + afwezigen[1] + afwezigen[2];
int lessenZonderAfwezigen = 0;

if (afwezigen[0] == 0)
{
    lessenZonderAfwezigen++;
}
if (afwezigen[1] == 0)
{
    lessenZonderAfwezigen++;
}
if (afwezigen[2] == 0)
{
    lessenZonderAfwezigen++;
}

Console.WriteLine($"Totaal aantal afwezigen: {totaal}");
Console.WriteLine($"Lessen zonder afwezigen: {lessenZonderAfwezigen}");
