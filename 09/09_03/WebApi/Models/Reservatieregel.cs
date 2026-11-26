namespace WebApi.Models;

public class Reservatieregel
{
    public int Id { get; set; }
    public int ReservatieId { get; set; }
    public string MateriaalNaam { get; set; } = string.Empty;
    public int Aantal { get; set; }
    public decimal Dagprijs { get; set; }
}
