using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class KlantRepository : GenericRepository<Klant>, IKlantRepository
{
    public KlantRepository(ElektroniXContext context) : base(context) { }

    public async Task<Klant?> GetKlantMetBestellingenAsync(int klantId)
    {
        return await _context.Klanten
            .Include(k => k.Bestellingen)
                .ThenInclude(b => b.OrderLijnen)
                    .ThenInclude(ol => ol.Product)
            .FirstOrDefaultAsync(k => k.Id == klantId);
    }
}
