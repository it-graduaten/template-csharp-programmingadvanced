using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class BestellingRepository : GenericRepository<Bestelling>, IBestellingRepository
{
    public BestellingRepository(ElektroniXContext context) : base(context) { }

    public async Task<Bestelling?> GetBestellingMetKlantAsync(int id)
    {
        return await _context.Bestellingen
            .Include(b => b.Klant)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Bestelling?> GetBestellingMetDetailsAsync(int id)
    {
        return await _context.Bestellingen
            .Include(b => b.Klant)
            .Include(b => b.OrderLijnen)
                .ThenInclude(ol => ol.Product)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}
