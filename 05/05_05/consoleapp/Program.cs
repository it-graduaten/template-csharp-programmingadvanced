Console.WriteLine("Hoeveel getallen wil je invoeren?");
int aantal = int.Parse(Console.ReadLine());

int[] getallen = new int[aantal];

for (int i = 0; i < getallen.Length; i++)
{
    Console.Write($"Geef getal {i + 1}: ");
    getallen[i] = int.Parse(Console.ReadLine());
}

Console.Write("Geef een getal om te zoeken: ");
int gezochtGetal = int.Parse(Console.ReadLine());

bool gevonden = false;

for (int i = 0; i < getallen.Length; i++)
{
    if (getallen[i] == gezochtGetal)
    {
        gevonden = true;
    }
}

if (gevonden)
{
    Console.WriteLine($"Het getal {gezochtGetal} is gevonden op de volgende index(en):");
    for (int i = 0; i < getallen.Length; i++)
    {
        if (getallen[i] == gezochtGetal)
        {
            Console.Write($"{i}");
            if (i < getallen.Length - 1 && getallen[i + 1] == gezochtGetal)
            {
                Console.Write(", ");
            }
        }
    }
    Console.WriteLine();
}
else
{
    Console.WriteLine($"Het getal {gezochtGetal} is niet gevonden.");
}
