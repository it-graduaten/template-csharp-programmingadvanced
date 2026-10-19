using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ElektroniXContext _context;

    // Private fields voor de repositories (voor lazy loading)
    private IBestellingRepository? _bestellingRepository;
    private IKlantRepository? _klantRepository;
    private IGenericRepository<Product>? _productRepository;
    private IGenericRepository<OrderLijn>? _orderLijnRepository;

    public UnitOfWork(ElektroniXContext context)
    {
        _context = context;
    }

    // Lazy Loading properties: Als een repo null is, maak hem dan aan.
    // Voor Bestelling gebruiken we de specifieke repository omdat deze extra methoden heeft
    public IBestellingRepository BestellingRepository =>
        _bestellingRepository ??= new BestellingRepository(_context);

    // Voor Klant gebruiken we de specifieke repository omdat deze extra methoden heeft
    public IKlantRepository KlantRepository =>
        _klantRepository ??= new KlantRepository(_context);

    // Voor de generieke repositories maken we direct een GenericRepository<T> aan
    public IGenericRepository<Product> ProductRepository =>
        _productRepository ??= new GenericRepository<Product>(_context);

    public IGenericRepository<OrderLijn> OrderLijnRepository =>
        _orderLijnRepository ??= new GenericRepository<OrderLijn>(_context);

    // De centrale plek waar SaveChangesAsync wordt aangeroepen
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
