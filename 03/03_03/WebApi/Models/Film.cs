namespace WebApi.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Regisseur { get; set; }
        public string Genre { get; set; }
        public int Speelduur { get; set; }
    }
}
