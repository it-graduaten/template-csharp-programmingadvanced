using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class KlantRepository : IKlantRepository
{
    private readonly FietsContext _context;

    public KlantRepository(FietsContext context)
    {
        _context = context;
    }

    public async Task<Klant> CreateAsync(Klant klant)
    {
        int maxId = await _context.Klanten.AnyAsync() ? await _context.Klanten.MaxAsync(x => x.Id) : 0;
        klant.Id = maxId + 1;
        klant.AangemaaktDatum = DateTime.Now;

        _context.Klanten.Add(klant);
        await _context.SaveChangesAsync();

        return klant;
    }

    public async Task<List<Klant>> GetAllAsync()
    {
        return await _context.Klanten
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Klant?> GetByIdAsync(int id)
    {
        return await _context.Klanten.FindAsync(id);
    }

    public async Task UpdateAsync(int id, Klant klant)
    {
        var existingKlant = await _context.Klanten.FindAsync(id);

        if (existingKlant != null)
        {
            existingKlant.Voornaam = klant.Voornaam;
            existingKlant.Naam = klant.Naam;
            existingKlant.AangemaaktDatum = klant.AangemaaktDatum;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var klantToDelete = await _context.Klanten.FindAsync(id);

        if (klantToDelete != null)
        {
            _context.Klanten.Remove(klantToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
