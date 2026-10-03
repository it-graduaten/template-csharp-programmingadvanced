using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class BestellingRepository : IBestellingRepository
{
    private readonly BibliotheekContext _context;

    public BestellingRepository(BibliotheekContext context)
    {
        _context = context;
    }

    public async Task<Bestelling> CreateAsync(Bestelling bestelling)
    {
        int maxId = await _context.Bestellingen.AnyAsync() ? await _context.Bestellingen.MaxAsync(x => x.Id) : 0;
        bestelling.Id = maxId + 1;
        bestelling.Besteldatum = DateTime.Now;

        _context.Bestellingen.Add(bestelling);
        await _context.SaveChangesAsync();

        return bestelling;
    }

    public async Task<List<Bestelling>> GetAllAsync()
    {
        return await _context.Bestellingen
            .OrderBy(x => x.KlantId)
            .ToListAsync();
    }

    public async Task<Bestelling?> GetByIdAsync(int id)
    {
        return await _context.Bestellingen.FindAsync(id);
    }

    public async Task UpdateAsync(int id, Bestelling bestelling)
    {
        var existingBestelling = await _context.Bestellingen.FindAsync(id);

        if (existingBestelling != null)
        {
            existingBestelling.ProductNaam = bestelling.ProductNaam;
            existingBestelling.Aantal = bestelling.Aantal;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var bestellingToDelete = await _context.Bestellingen.FindAsync(id);

        if (bestellingToDelete != null)
        {
            _context.Bestellingen.Remove(bestellingToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
