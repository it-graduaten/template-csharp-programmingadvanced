using WebApi.Models;

namespace WebApi.Repositories;

public interface IUnitOfWork
{
    IGenericRepository<Klant> KlantRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }
    Task<int> SaveChangesAsync();
}
