using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ElektroniXContext _context;

    // Private fields voor de repositories (voor lazy loading)
    private IGenericRepository<Klant>? _klantRepository;
    private IGenericRepository<Product>? _productRepository;

    public UnitOfWork(ElektroniXContext context)
    {
        _context = context;
    }

    // Lazy Loading properties: Als een repo null is, maak hem dan aan.
    public IGenericRepository<Klant> KlantRepository =>
        _klantRepository ??= new GenericRepository<Klant>(_context);

    public IGenericRepository<Product> ProductRepository =>
        _productRepository ??= new GenericRepository<Product>(_context);

    // De centrale plek waar SaveChangesAsync wordt aangeroepen
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
