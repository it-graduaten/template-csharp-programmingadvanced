namespace PakketApi;

public class PakketRepository : IPakketRepository
{
    private readonly List<Pakket> _pakketten = new()
    {
        new Pakket { Id = 1, Status = "Onderweg" },
        new Pakket { Id = 2, Status = "Bezorgd" }
    };

    public Task<Pakket?> ZoekOpIdAsync(int id)
    {
        Pakket? pakket = _pakketten.Find(p => p.Id == id);
        return Task.FromResult(pakket);
    }
}
