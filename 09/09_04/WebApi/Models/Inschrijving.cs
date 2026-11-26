namespace WebApi.Models;

public class Inschrijving
{
    public int Id { get; set; }
    public int DeelnemerId { get; set; }
    public int CursusId { get; set; }
    public Cursus Cursus { get; set; } = new();
    public int AantalPlaatsen { get; set; }
}
