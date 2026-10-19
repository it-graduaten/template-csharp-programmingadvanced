using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ElektroniXContext _context;
    private IBestellingRepository? _bestellingRepository;
    private IGenericRepository<Klant>? _klantRepository;
    private IGenericRepository<Product>? _productRepository;
    private IGenericRepository<OrderLijn>? _orderLijnRepository;

    public UnitOfWork(ElektroniXContext context)
    {
        _context = context;
    }

    public IBestellingRepository BestellingRepository =>
        _bestellingRepository ??= new BestellingRepository(_context);

    public IGenericRepository<Klant> KlantRepository =>
        _klantRepository ??= new GenericRepository<Klant>(_context);

    public IGenericRepository<Product> ProductRepository =>
        _productRepository ??= new GenericRepository<Product>(_context);

    public IGenericRepository<OrderLijn> OrderLijnRepository =>
        _orderLijnRepository ??= new GenericRepository<OrderLijn>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
