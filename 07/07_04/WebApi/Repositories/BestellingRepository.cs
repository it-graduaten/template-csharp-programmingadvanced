using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class BestellingRepository : GenericRepository<Bestelling>, IBestellingRepository
{
    public BestellingRepository(ElektroniXContext context) : base(context) { }

    public async Task<IEnumerable<Bestelling>> GetBestellingenByKlantAsync(int klantId)
    {
        return await _context.Bestellingen
            .Where(b => b.KlantId == klantId)
            .OrderByDescending(b => b.Id)
            .ToListAsync();
    }
}
