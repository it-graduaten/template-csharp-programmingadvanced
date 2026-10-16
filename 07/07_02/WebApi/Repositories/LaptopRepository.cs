using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class LaptopRepository : GenericRepository<Laptop>, ILaptopRepository
{
    public LaptopRepository(LaptopCatalogusContext context) : base(context) { }

    public async Task<IEnumerable<Laptop>> GetLaptopsByMerkAsync(string merk)
    {
        return await _context.Laptops
            .Where(l => l.Merk.ToLower() == merk.ToLower())
            .OrderBy(l => l.Prijs)
            .ToListAsync();
    }

    public async Task<IEnumerable<Laptop>> GetLaptopsByRamInGBAsync(int ramInGB)
    {
        return await _context.Laptops
            .Where(l => l.RamInGB >= ramInGB)
            .OrderBy(l => l.RamInGB)
            .ThenBy(l => l.Prijs)
            .ToListAsync();
    }

    public async Task<IEnumerable<Laptop>> GetLaptopsSortedByPrijsAsync(bool descending)
    {
        if (descending)
        {
            return await _context.Laptops
                .OrderByDescending(l => l.Prijs)
                .ToListAsync();
        }
        else
        {
            return await _context.Laptops
                .OrderBy(l => l.Prijs)
                .ToListAsync();
        }
    }

    public async Task<int> CountLaptopsByMerkAsync(string merk)
    {
        return await _context.Laptops
            .CountAsync(l => l.Merk.ToLower() == merk.ToLower());
    }
}
