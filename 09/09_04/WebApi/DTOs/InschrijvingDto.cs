namespace WebApi.DTOs;

public class InschrijvingDto
{
    public int CursusId { get; set; }
    public string CursusTitel { get; set; } = string.Empty;
    public int AantalPlaatsen { get; set; }
    public decimal TotaalPrijs { get; set; }
}
