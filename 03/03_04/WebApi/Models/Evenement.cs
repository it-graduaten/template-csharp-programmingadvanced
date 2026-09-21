namespace WebApi.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public string Datum { get; set; }
        public int MaxDeelnemers { get; set; }
        public int GeregistreerdeDeelnemers { get; set; }
    }
}
