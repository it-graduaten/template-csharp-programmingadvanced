using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class BibliotheekContext : DbContext
{
    public BibliotheekContext(DbContextOptions<BibliotheekContext> options)
        : base(options) { }

    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Bestelling> Bestellingen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.ToTable("Klant");
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
    }
}
