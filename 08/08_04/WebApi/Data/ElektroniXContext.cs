using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class ElektroniXContext : DbContext
{
    public ElektroniXContext(DbContextOptions<ElektroniXContext> options)
        : base(options) { }

    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Product> Producten { get; set; }
    public DbSet<Bestelling> Bestellingen { get; set; }
    public DbSet<OrderLijn> OrderLijnen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.ToTable("Klanten");
            entity.Property(p => p.Naam).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Voornaam).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(100);

            entity.HasMany(k => k.Bestellingen)
                .WithOne(b => b.Klant)
                .HasForeignKey(b => b.KlantId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Producten");
            entity.Property(p => p.Naam).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Prijs).IsRequired().HasPrecision(18, 2);
            entity.Property(p => p.Voorraad).IsRequired();
        });

        modelBuilder.Entity<Bestelling>(entity =>
        {
            entity.ToTable("Bestellingen");
            entity.HasOne(b => b.Klant)
                .WithMany(k => k.Bestellingen)
                .HasForeignKey(b => b.KlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany(b => b.OrderLijnen)
                .WithOne(ol => ol.Bestelling)
                .HasForeignKey(ol => ol.BestellingId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.Property(p => p.BestelDatum).IsRequired();
        });

        modelBuilder.Entity<OrderLijn>(entity =>
        {
            entity.ToTable("OrderLijnen");
            entity.HasOne(ol => ol.Product)
                .WithMany()
                .HasForeignKey(ol => ol.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<Klant>().HasData(
            new Klant { Id = 1, Naam = "Van Der Neffe", Voornaam = "Leon", Email = "leon.vanderneffe@email.be" },
            new Klant { Id = 2, Naam = "Van De Kasseinen", Voornaam = "Firmin", Email = "firmin.vande.kasseinen@email.be" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Naam = "Laptop Pro", Prijs = 2499.00m, Voorraad = 15 },
            new Product { Id = 2, Naam = "Monitor 4K", Prijs = 899.00m, Voorraad = 30 },
            new Product { Id = 3, Naam = "Toetsenbord", Prijs = 149.00m, Voorraad = 50 }
        );

        modelBuilder.Entity<Bestelling>().HasData(
            new Bestelling { Id = 1, KlantId = 1, BestelDatum = new DateTime(2025, 1, 15) },
            new Bestelling { Id = 2, KlantId = 1, BestelDatum = new DateTime(2025, 2, 20) },
            new Bestelling { Id = 3, KlantId = 2, BestelDatum = new DateTime(2025, 3, 10) }
        );

        modelBuilder.Entity<OrderLijn>().HasData(
            new OrderLijn { Id = 1, BestellingId = 1, ProductId = 1, Aantal = 1 },
            new OrderLijn { Id = 2, BestellingId = 1, ProductId = 3, Aantal = 2 },
            new OrderLijn { Id = 3, BestellingId = 2, ProductId = 2, Aantal = 1 },
            new OrderLijn { Id = 4, BestellingId = 3, ProductId = 1, Aantal = 2 }
        );
    }
}
