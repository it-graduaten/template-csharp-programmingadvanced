using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class FietsCatalogusContext : DbContext
{
    public FietsCatalogusContext(DbContextOptions<FietsCatalogusContext> options)
        : base(options) { }

    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Bestelling> Bestellingen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.ToTable("Klanten");

            entity.Property(p => p.Naam).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Voornaam).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Bestelling>(entity =>
        {
            entity.ToTable("Bestellingen");

            entity.HasOne(b => b.Klant)
                .WithMany()
                .HasForeignKey(b => b.KlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.Property(p => p.BestelDatum).IsRequired();
        });

        modelBuilder.Entity<Klant>().HasData(
            new Klant { Id = 1, Naam = "Van Der Neffe", Voornaam = "Leon", Email = "leon.vanderneffe@email.be" },
            new Klant { Id = 2, Naam = "Van De Kasseinen", Voornaam = "Firmin", Email = "firmin.vande.kasseinen@email.be" },
            new Klant { Id = 3, Naam = "Kiekeboe", Voornaam = "Marcel", Email = "marcel.kiekeboe@email.be" }
        );

        modelBuilder.Entity<Bestelling>().HasData(
            new Bestelling { Id = 1, KlantId = 1, BestelDatum = new DateTime(2025, 1, 15) },
            new Bestelling { Id = 2, KlantId = 1, BestelDatum = new DateTime(2025, 2, 20) },
            new Bestelling { Id = 3, KlantId = 2, BestelDatum = new DateTime(2025, 3, 10) }
        );
    }
}
