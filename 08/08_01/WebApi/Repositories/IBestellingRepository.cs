using WebApi.Models;

namespace WebApi.Repositories;

public interface IBestellingRepository : IGenericRepository<Bestelling>
{
    Task<Bestelling?> GetBestellingMetKlantAsync(int id);
}
