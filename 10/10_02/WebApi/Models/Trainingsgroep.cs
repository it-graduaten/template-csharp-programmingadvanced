namespace WebApi.Models;

public class Trainingsgroep
{
    public int Id { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string Dag { get; set; } = string.Empty;
    public int MaximumLeden { get; set; }
    public bool Actief { get; set; }
}
