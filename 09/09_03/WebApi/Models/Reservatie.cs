namespace WebApi.Models;

public class Reservatie
{
    public int Id { get; set; }
    public int KlantId { get; set; }
    public Klant Klant { get; set; } = new();
    public List<Reservatieregel> Regels { get; set; } = [];
}
