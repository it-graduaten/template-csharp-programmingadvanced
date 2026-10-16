namespace WebApi.Models;

public class Klant : IModel
{
    public int Id { get; set; }
    public string Naam { get; set; } = "";
    public string Voornaam { get; set; } = "";
    public string Email { get; set; } = "";
    public List<Bestelling> Bestellingen { get; set; } = [];
}
