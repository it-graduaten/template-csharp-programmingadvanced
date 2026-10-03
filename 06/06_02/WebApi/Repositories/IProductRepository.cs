using WebApi.Models;

namespace WebApi.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product);
    Task DeleteAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task UpdateAsync(int id, Product product);
}
