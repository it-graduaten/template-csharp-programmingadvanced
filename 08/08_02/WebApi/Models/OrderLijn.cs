namespace WebApi.Models;

public class OrderLijn : IModel
{
    public int Id { get; set; }
    public int BestellingId { get; set; }
    public int ProductId { get; set; }
    public int Aantal { get; set; }
    public Bestelling? Bestelling { get; set; }
    public Product? Product { get; set; }
}
