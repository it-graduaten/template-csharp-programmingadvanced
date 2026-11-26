namespace WebApi.DTOs;

public class ReserveringDto
{
    public int Id { get; set; }
    public int ApparaatId { get; set; }
    public string ApparaatNaam { get; set; } = string.Empty;
    public decimal Dagprijs { get; set; }
    public string Klantnaam { get; set; } = string.Empty;
    public int AantalDagen { get; set; }
    public decimal TotaalPrijs { get; set; }
}
