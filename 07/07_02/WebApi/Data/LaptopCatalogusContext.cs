using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class LaptopCatalogusContext : DbContext
{
    public LaptopCatalogusContext(DbContextOptions<LaptopCatalogusContext> options)
        : base(options) { }

    public DbSet<Laptop> Laptops { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.ToTable("Laptops");

            entity.Property(p => p.Merk).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Processor).IsRequired().HasMaxLength(100);
            entity.Property(p => p.RamInGB).IsRequired();
            entity.Property(p => p.Prijs).IsRequired().HasPrecision(18, 2);
            entity.Property(p => p.GPU).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Laptop>().HasData(
            new Laptop { Id = 1, Merk = "Apple", Processor = "M3 Pro", RamInGB = 18, Prijs = 2999.00m, GPU = "Radeon" },
            new Laptop { Id = 2, Merk = "Dell", Processor = "Intel i7", RamInGB = 16, Prijs = 1899.00m, GPU = "RTX 4060" },
            new Laptop { Id = 3, Merk = "Lenovo", Processor = "Ryzen 7", RamInGB = 32, Prijs = 2199.00m, GPU = "Radeon 780M" },
            new Laptop { Id = 4, Merk = "HP", Processor = "Intel i5", RamInGB = 8, Prijs = 1099.00m, GPU = "Iris Xe" },
            new Laptop { Id = 5, Merk = "Asus", Processor = "Ryzen 9", RamInGB = 64, Prijs = 3499.00m, GPU = "RTX 4080" }
        );
    }
}
