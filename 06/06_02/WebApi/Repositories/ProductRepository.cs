using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly FietsContext _context;

    public ProductRepository(FietsContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        int maxId = await _context.Producten.AnyAsync() ? await _context.Producten.MaxAsync(x => x.Id) : 0;
        product.Id = maxId + 1;

        _context.Producten.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Producten
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Producten.FindAsync(id);
    }

    public async Task UpdateAsync(int id, Product product)
    {
        var existingProduct = await _context.Producten.FindAsync(id);

        if (existingProduct != null)
        {
            existingProduct.Naam = product.Naam;
            existingProduct.Beschrijving = product.Beschrijving;
            existingProduct.Prijs = product.Prijs;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var productToDelete = await _context.Producten.FindAsync(id);

        if (productToDelete != null)
        {
            _context.Producten.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
