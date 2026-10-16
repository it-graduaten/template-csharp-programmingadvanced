using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class ElektroniXContext : DbContext
{
    public ElektroniXContext(DbContextOptions<ElektroniXContext> options)
        : base(options) { }

    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Product> Producten { get; set; }

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

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Producten");
            entity.Property(p => p.Naam).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Prijs).IsRequired().HasPrecision(18, 2);
        });

        modelBuilder.Entity<Klant>().HasData(
            new Klant { Id = 1, Naam = "Van Der Neffe", Voornaam = "Leon", Email = "leon.vanderneffe@email.be" },
            new Klant { Id = 2, Naam = "Van De Kasseinen", Voornaam = "Firmin", Email = "firmin.vande.kasseinen@email.be" },
            new Klant { Id = 3, Naam = "Kiekeboe", Voornaam = "Marcel", Email = "marcel.kiekeboe@email.be" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Naam = "Laptop Pro", Prijs = 2499.00m, Voorraad = 15 },
            new Product { Id = 2, Naam = "Monitor 4K", Prijs = 899.00m, Voorraad = 30 },
            new Product { Id = 3, Naam = "Toetsenbord", Prijs = 149.00m, Voorraad = 50 }
        );
    }
}
