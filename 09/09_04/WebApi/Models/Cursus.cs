namespace WebApi.Models;

public class Cursus
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public decimal Prijs { get; set; }
    public string InternCommentaar { get; set; } = string.Empty;
}
