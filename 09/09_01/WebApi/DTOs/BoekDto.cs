namespace WebApi.DTOs;

public class BoekDto
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
}
