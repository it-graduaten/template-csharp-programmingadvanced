using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FietsCatalogusContext _context;
    private IBestellingRepository? _bestellingRepository;
    private IGenericRepository<Klant>? _klantRepository;

    public UnitOfWork(FietsCatalogusContext context)
    {
        _context = context;
    }

    public IBestellingRepository BestellingRepository =>
        _bestellingRepository ??= new BestellingRepository(_context);

    public IGenericRepository<Klant> KlantRepository =>
        _klantRepository ??= new GenericRepository<Klant>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
