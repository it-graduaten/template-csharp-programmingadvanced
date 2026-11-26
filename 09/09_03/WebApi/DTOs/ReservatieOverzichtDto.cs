namespace WebApi.DTOs;

public class ReservatieOverzichtDto
{
    public int Id { get; set; }
    public string KlantNaam { get; set; } = string.Empty;
    public decimal TotaalPrijs { get; set; }
    public List<ReservatieregelDto> Regels { get; set; } = [];
}
