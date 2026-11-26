namespace WebApi.DTOs;

public class UitleningDto
{
    public int Id { get; set; }
    public string MateriaalNaam { get; set; } = string.Empty;
    public string Uitlener { get; set; } = string.Empty;
    public int AantalDagen { get; set; }
}
