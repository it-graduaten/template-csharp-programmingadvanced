namespace WebApi.DTOs;

public class ActiviteitCreateDto
{
    public string Naam { get; set; } = string.Empty;
    public string Beschrijving { get; set; } = string.Empty;
    public int MaximumDeelnemers { get; set; }
}
