namespace WebApi.Models;

public class Activiteit
{
    public int Id { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string Beschrijving { get; set; } = string.Empty;
    public int MaximumDeelnemers { get; set; }
    public bool Goedgekeurd { get; set; }
}
