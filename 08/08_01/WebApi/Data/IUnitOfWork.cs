using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Data;

public interface IUnitOfWork
{
    IBestellingRepository BestellingRepository { get; }
    IGenericRepository<Klant> KlantRepository { get; }
    Task<int> SaveChangesAsync();
}
