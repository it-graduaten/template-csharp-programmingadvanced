namespace WebApi.DTOs;

public class TentoonstellingDto
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public string Beschrijving { get; set; } = string.Empty;
    public int MaximaalAantalBezoekers { get; set; }
    public bool Gepubliceerd { get; set; }
}
