namespace WebApi.DTOs;

public class TrainingsgroepDto
{
    public int Id { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string Dag { get; set; } = string.Empty;
    public int MaximumLeden { get; set; }
    public bool Actief { get; set; }
}
