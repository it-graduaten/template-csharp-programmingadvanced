Console.Write("Geef een getal: ");
int getal = int.Parse(Console.ReadLine());

if (getal >= 1 && getal <= 10)
{
    Console.WriteLine("Het getal ligt tussen 1 en 10");
}
else
{
    Console.WriteLine("Het getal ligt buiten het bereik van 1 tot 10.");
}
