# 07_02

## Leerdoel

Na deze oefening kan je een specifieke repository maken die overerft van de generieke repository en uitgebreid wordt met gespecialiseerde query-methodes.

Je leert hoe je een specifieke interface laat overerven van `IGenericRepository<T>`, hoe je een specifieke repository-klasse laat overerven van `GenericRepository<T>`, en hoe je extra methodes toevoegt die gebruikmaken van de `protected _context` uit de basisklasse zonder de basis-CRUD-code te dupliceren.

## Opdracht

De laptopwinkel **LaptopExpert** wil haar laptopcatalogus-API migreren van een in-memory lijst naar een echte PostgreSQL-database met Entity Framework Core. Na de basis-CRUD-operaties wil men ook gefilterde zoekopdrachten ondersteunen. Omdat men de generieke repository wil hergebruiken, maakt men een specifieke repository die overerft van `GenericRepository<Laptop>` en extra methodes toevoegt.

Jouw taak is om de `ILaptopRepository`-interface en `LaptopRepository`-klasse te implementeren, waarbij de generieke CRUD-methodes niet opnieuw geschreven hoeven te worden.

### Het Laptop Model

Maak een Modelklasse `Laptop` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de laptop |
| Merk | string | Het merk van de laptop |
| Processor | string | Het type processor |
| RamInGB | int | De hoeveelheid RAM in GB |
| Prijs | decimal | De prijs van de laptop |
| GPU | string | Het type grafische kaart |

Het model moet overerven van de `IModel`-interface.

### De IModel Interface

De `IModel`-interface is reeds aangemaakt in de map **Models**:

```csharp
namespace WebApi.Models;

public interface IModel
{
    int Id { get; set; }
}
```

### De DbContext

De context is reeds aangemaakt en geregistreerd. Gebruik de volgende context:

```csharp
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
    }
}
```

### Seed data toevoegen

Voeg de volgende seed data toe in de `OnModelCreating`-methode van de context:

| Id | Merk | Processor | RamInGB | Prijs | GPU |
| -- | ---- | --------- | ------- | ----- | --- |
| 1 | Apple | M3 Pro | 18 | 2999.00 | Radeon |
| 2 | Dell | Intel i7 | 16 | 1899.00 | RTX 4060 |
| 3 | Lenovo | Ryzen 7 | 32 | 2199.00 | Radeon 780M |
| 4 | HP | Intel i5 | 8 | 1099.00 | Iris Xe |
| 5 | Asus | Ryzen 9 | 64 | 3499.00 | RTX 4080 |

### De generieke Repository Interface

De interface **IGenericRepository<TEntity>** is reeds aangemaakt in de map **Repositories**:

```csharp
using WebApi.Models;

namespace WebApi.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class, IModel
{
    void Add(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> ExistsAsync(int id);
    Task<int[]> GetExistingIdsAsync();
}
```

### De generieke Repository Implementatie

De klasse **GenericRepository<TEntity>** is reeds aangemaakt in de map **Repositories**:

```csharp
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IModel
{
    protected readonly LaptopCatalogusContext _context;

    public GenericRepository(LaptopCatalogusContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Set<TEntity>().AnyAsync(e => e.Id == id);
    }

    public async Task<int[]> GetExistingIdsAsync()
    {
        return await _context.Set<TEntity>()
            .Select(e => e.Id)
            .ToArrayAsync();
    }
}
```

### De specifieke Repository Interface

Maak een nieuwe interface **ILaptopRepository** in de map **Repositories** die overerft van `IGenericRepository<Laptop>`. Je hoeft de basis-CRUD-methodes niet opnieuw te declareren — deze worden automatisch geërfd.

```csharp
using WebApi.Models;

namespace WebApi.Repositories;

public interface ILaptopRepository : IGenericRepository<Laptop>
{
    Task<IEnumerable<Laptop>> GetLaptopsByMerkAsync(string merk);
    Task<IEnumerable<Laptop>> GetLaptopsByRamInGBAsync(int ramInGB);
    Task<IEnumerable<Laptop>> GetLaptopsSortedByPrijsAsync(bool descending);
    Task<int> CountLaptopsByMerkAsync(string merk);
}
```

Deze interface voegt vier gespecialiseerde methodes toe:
- `GetLaptopsByMerkAsync` — filter laptops op merk (case-insensitive);
- `GetLaptopsByRamInGBAsync` — filter laptops op RAM-geheugen;
- `GetLaptopsSortedByPrijsAsync` — sorteer laptops op prijs (oplopend of aflopend);
- `CountLaptopsByMerkAsync` — tel het aantal laptops per merk.

### De specifieke Repository Implementatie

Maak een klasse **LaptopRepository** in de map **Repositories** die overerft van `GenericRepository<Laptop>` en de `ILaptopRepository`-interface implementeert.

De repository moet:
- de `DbContext` doorgeven aan de base constructor (`base(context)`);
- alle CRUD-methodes **niet** opnieuw implementeren — deze komen automatisch van `GenericRepository<Laptop>`;
- de vier gespecialiseerde methodes asynchroon implementeren met de juiste EF Core async methodes;
- de `-Async` suffix gebruiken voor de namen van alle asynchrone methodes;
- de `protected _context` uit de basisklasse gebruiken om queries uit te voeren;
- de `ToLower()` methode gebruiken voor case-insensitive vergelijkingen;
- lege lijsten teruggeven wanneer er geen resultaten zijn (geen null).

```csharp
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class LaptopRepository : GenericRepository<Laptop>, ILaptopRepository
{
    public LaptopRepository(LaptopCatalogusContext context) : base(context) { }

    public async Task<IEnumerable<Laptop>> GetLaptopsByMerkAsync(string merk)
    {
        return await _context.Laptops
            .Where(l => l.Merk.ToLower() == merk.ToLower())
            .OrderBy(l => l.Prijs)
            .ToListAsync();
    }

    public async Task<IEnumerable<Laptop>> GetLaptopsByRamInGBAsync(int ramInGB)
    {
        return await _context.Laptops
            .Where(l => l.RamInGB >= ramInGB)
            .OrderBy(l => l.RamInGB)
            .ThenBy(l => l.Prijs)
            .ToListAsync();
    }

    public async Task<IEnumerable<Laptop>> GetLaptopsSortedByPrijsAsync(bool descending)
    {
        if (descending)
        {
            return await _context.Laptops
                .OrderByDescending(l => l.Prijs)
                .ToListAsync();
        }
        else
        {
            return await _context.Laptops
                .OrderBy(l => l.Prijs)
                .ToListAsync();
        }
    }

    public async Task<int> CountLaptopsByMerkAsync(string merk)
    {
        return await _context.Laptops
            .CountAsync(l => l.Merk.ToLower() == merk.ToLower());
    }
}
```

### Dependency Injection

Registreer de repository in `Program.cs` met `AddScoped`:

```csharp
builder.Services.AddScoped<ILaptopRepository, LaptopRepository>();
```
