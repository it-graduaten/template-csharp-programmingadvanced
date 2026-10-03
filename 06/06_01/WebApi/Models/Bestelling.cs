namespace WebApi.Models;

public class Bestelling
{
    public int Id { get; set; }
    public int KlantId { get; set; }
    public Klant? Klant { get; set; } = default!;
    public string ProductNaam { get; set; } = default!;
    public int Aantal { get; set; }
    public DateTime Besteldatum { get; set; }
}
