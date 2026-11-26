namespace WebApi.Models;

public class Uitlening
{
    public int Id { get; set; }
    public int MateriaalId { get; set; }
    public string Uitlener { get; set; } = string.Empty;
    public int AantalDagen { get; set; }
}
