namespace WebApi.DTOs;

public class ReservatieregelDto
{
    public string MateriaalNaam { get; set; } = string.Empty;
    public int Aantal { get; set; }
    public decimal Dagprijs { get; set; }
    public decimal RegelTotaal { get; set; }
}
