namespace WebApi.Models;

public class Deelnemer
{
    public int Id { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Inschrijving> Inschrijvingen { get; set; } = [];
}
