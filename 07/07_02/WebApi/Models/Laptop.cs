namespace WebApi.Models;

public class Laptop : IModel
{
    public int Id { get; set; }
    public string Merk { get; set; } = "";
    public string Processor { get; set; } = "";
    public int RamInGB { get; set; }
    public decimal Prijs { get; set; }
    public string GPU { get; set; } = "";
}
