using WebApi.Models;

namespace WebApi.Repositories;

public interface IBestellingRepository : IGenericRepository<Bestelling>
{
    Task<IEnumerable<Bestelling>> GetBestellingenByKlantAsync(int klantId);
}
