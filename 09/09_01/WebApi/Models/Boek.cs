namespace WebApi.Models;

public class Boek
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public string InterneNotitie { get; set; } = string.Empty;
    public string VoorraadLocatie { get; set; } = string.Empty;
}
