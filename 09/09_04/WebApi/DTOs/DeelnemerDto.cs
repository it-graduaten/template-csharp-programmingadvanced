namespace WebApi.DTOs;

public class DeelnemerDto
{
    public int Id { get; set; }
    public string Naam { get; set; } = string.Empty;
    public List<InschrijvingDto> Inschrijvingen { get; set; } = [];
}
