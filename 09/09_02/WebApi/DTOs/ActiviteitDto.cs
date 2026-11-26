namespace WebApi.DTOs;

public class ActiviteitDto
{
    public int Id { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string Beschrijving { get; set; } = string.Empty;
    public int MaximumDeelnemers { get; set; }
    public bool Goedgekeurd { get; set; }
}
