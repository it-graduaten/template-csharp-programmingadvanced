namespace WebApi.Models;

public class Reservering
{
    public int Id { get; set; }
    public int ApparaatId { get; set; }
    public string Klantnaam { get; set; } = string.Empty;
    public int AantalDagen { get; set; }
}
