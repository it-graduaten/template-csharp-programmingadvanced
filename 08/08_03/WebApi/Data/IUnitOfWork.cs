using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Data;

public interface IUnitOfWork
{
    IKlantRepository KlantRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }
    IGenericRepository<OrderLijn> OrderLijnRepository { get; }
    Task<int> SaveChangesAsync();
}
