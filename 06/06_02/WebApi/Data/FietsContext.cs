using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class FietsContext : DbContext
{
    public FietsContext(DbContextOptions<FietsContext> options)
        : base(options) { }

    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Product> Producten { get; set; }
    public DbSet<Bestelling> Bestellingen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.ToTable("Klant");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");
        });

        modelBuilder.Entity<Bestelling>(entity =>
        {
            entity.ToTable("Bestelling");

            entity.HasOne(p => p.Klant)
                .WithMany(x => x.Bestellingen)
                .HasForeignKey(y => y.KlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<Klant>().HasData(
            new Klant { Id = 1, Voornaam = "Leon", Naam = "Van Der Neffe", AangemaaktDatum = new DateTime(2022, 10, 1) },
            new Klant { Id = 2, Voornaam = "Firmin", Naam = "Van De Kasseinen", AangemaaktDatum = new DateTime(2022, 10, 2) },
            new Klant { Id = 3, Voornaam = "Marcel", Naam = "Kiekeboe", AangemaaktDatum = new DateTime(2022, 10, 3) }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Naam = "fiets", Beschrijving = "Dit is een fiets", Prijs = 100.00m },
            new Product { Id = 2, Naam = "koersfiets", Beschrijving = "Dit is een mooie koersfiets", Prijs = 200.00m },
            new Product { Id = 3, Naam = "auto", Beschrijving = "Dit is een auto", Prijs = 2000.00m }
        );

        modelBuilder.Entity<Bestelling>().HasData(
            new Bestelling { Id = 1, KlantId = 1 },
            new Bestelling { Id = 2, KlantId = 2 },
            new Bestelling { Id = 3, KlantId = 3 },
            new Bestelling { Id = 4, KlantId = 2 },
            new Bestelling { Id = 5, KlantId = 3 }
        );
    }
}
