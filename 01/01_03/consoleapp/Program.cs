int nationale = int.Parse(Console.ReadLine());
int internationale = int.Parse(Console.ReadLine());

int aantal = nationale + internationale;
double verzendkosten = aantal * 0.12 + 23;
double totaalMetBTW = verzendkosten * 1.21;

Console.WriteLine(totaalMetBTW.ToString("N2"));
