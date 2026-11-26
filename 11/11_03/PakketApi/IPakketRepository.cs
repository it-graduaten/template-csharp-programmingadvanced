namespace PakketApi;

public interface IPakketRepository
{
    Task<Pakket?> ZoekOpIdAsync(int id);
}
