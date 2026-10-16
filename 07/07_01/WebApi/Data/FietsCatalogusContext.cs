using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class FietsCatalogusContext : DbContext
{
    public FietsCatalogusContext(DbContextOptions<FietsCatalogusContext> options)
        : base(options) { }

    public DbSet<Fiets> Fietsen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Fiets>(entity =>
        {
            entity.ToTable("Fietsen");

            entity.Property(p => p.Merk).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Type).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Kleur).IsRequired().HasMaxLength(30);
            entity.Property(p => p.Prijs).IsRequired().HasPrecision(18, 2);
        });

        modelBuilder.Entity<Fiets>().HasData(
            new Fiets { Id = 1, Merk = "Trek", Type = "Mountainbike", Kleur = "Zwart", Prijs = 1200.00m, Voorraad = 5 },
            new Fiets { Id = 2, Merk = "Specialized", Type = "Racefiets", Kleur = "Rood", Prijs = 2500.00m, Voorraad = 3 },
            new Fiets { Id = 3, Merk = "Gazelle", Type = "Stadsfiets", Kleur = "Blauw", Prijs = 800.00m, Voorraad = 12 },
            new Fiets { Id = 4, Merk = "Giant", Type = "Mountainbike", Kleur = "Groen", Prijs = 1500.00m, Voorraad = 7 },
            new Fiets { Id = 5, Merk = "Koga", Type = "Stadsfiets", Kleur = "Wit", Prijs = 950.00m, Voorraad = 8 }
        );
    }
}
