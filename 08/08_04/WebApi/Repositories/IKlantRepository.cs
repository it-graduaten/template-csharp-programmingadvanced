using WebApi.Models;

namespace WebApi.Repositories;

public interface IKlantRepository : IGenericRepository<Klant>
{
    Task<Klant?> GetKlantMetBestellingenAsync(int klantId);
}
