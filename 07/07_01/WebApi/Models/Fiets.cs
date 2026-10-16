namespace WebApi.Models;

public class Fiets : IModel
{
    public int Id { get; set; }
    public string Merk { get; set; } = "";
    public string Type { get; set; } = "";
    public string Kleur { get; set; } = "";
    public decimal Prijs { get; set; }
    public int Voorraad { get; set; }
}
