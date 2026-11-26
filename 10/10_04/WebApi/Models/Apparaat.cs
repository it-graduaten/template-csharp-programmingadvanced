namespace WebApi.Models;

public class Apparaat
{
    public int Id { get; set; }
    public string Naam { get; set; } = string.Empty;
    public decimal Dagprijs { get; set; }
    public bool Beschikbaar { get; set; }
}
