namespace WebApi.Models;

public class Bestelling : IModel
{
    public int Id { get; set; }
    public int KlantId { get; set; }
    public Klant? Klant { get; set; }
    public List<OrderLijn> OrderLijnen { get; set; } = new();
    public DateTime BestelDatum { get; set; }
}
