using WebApi.Models;

namespace WebApi.Repositories;

public interface IKlantRepository
{
    Task<Klant> CreateAsync(Klant klant);
    Task DeleteAsync(int id);
    Task<List<Klant>> GetAllAsync();
    Task<Klant?> GetByIdAsync(int id);
    Task UpdateAsync(int id, Klant klant);
}
