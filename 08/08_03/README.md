# 08_03

## Leerdoel

Na deze oefening kan je een gespecialiseerde KlantRepository bouwen die gebruikmaakt van `.Include()` en `.ThenInclude()` om een klant op te halen met al hun bestellingen én de producten in die bestellingen.

Je leert hoe je vanuit de andere richting van de relatie navigeert: van Klant naar Bestellingen, naar OrderLijnen, en dan naar Producten — met meerdere `.ThenInclude()`-calls.

## Opdracht

De webshop **ElektroniX** wil een endpoint bouwen waarmee ze alle bestellingen van een klant kunnen opvragen, inclusief alle producten in die bestellingen. In plaats van het N+1 query probleem (één query per bestelling, één query per orderlijn, één query per product) willen ze dit allemaal in één enkele database-query doen met Eager Loading. Jouw taak is om een gespecialiseerde `IKlantRepository` te bouwen.

### De Modellen

#### Klant Model

Maak een Modelklasse `Klant` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de klant |
| Naam | string | De achternaam van de klant |
| Voornaam | string | De voornaam van de klant |
| Email | string | Het e-mailadres van de klant |
| Bestellingen | List<Bestelling> | De bestellingen van deze klant |

Het model moet overerven van de `IModel`-interface.

#### Product Model

Maak een Modelklasse `Product` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van het product |
| Naam | string | De naam van het product |
| Prijs | decimal | De prijs van het product |
| Voorraad | int | Het aantal beschikbare stuks op voorraad |

Het model moet overerven van de `IModel`-interface.

#### Bestelling Model

Maak een Modelklasse `Bestelling` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de bestelling |
| KlantId | int | De FK naar de klant |
| Klant | Klant? | Navigation Property naar de klant |
| OrderLijnen | List<OrderLijn> | De orderlijnen van deze bestelling |
| BestelDatum | DateTime | De datum waarop de bestelling werd geplaatst |

Het model moet overerven van de `IModel`-interface.

#### OrderLijn Model

Maak een Modelklasse `OrderLijn` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de orderlijn |
| BestellingId | int | De FK naar de bestelling |
| ProductId | int | De FK naar het product |
| Aantal | int | Het aantal bestelde stuks |
| Bestelling | Bestelling? | Navigation Property naar de bestelling |
| Product | Product? | Navigation Property naar het product |

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
    }
}
```

### Seed data toevoegen

Voeg de volgende seed data toe in de `OnModelCreating`-methode van de context:

| Id | Naam | Voornaam | Email |
| -- | ---- | -------- | ----- |
| 1 | Van Der Neffe | Leon | leon.vanderneffe@email.be |
| 2 | Van De Kasseinen | Firmin | firmin.vande.kasseinen@email.be |

| Id | Naam | Prijs | Voorraad |
| -- | ---- | ----- | -------- |
| 1 | Laptop Pro | 2499.00 | 15 |
| 2 | Monitor 4K | 899.00 | 30 |
| 3 | Toetsenbord | 149.00 | 50 |

| Id | KlantId | BestelDatum |
| -- | ------- | ----------- |
| 1 | 1 | 2025-01-15 |
| 2 | 1 | 2025-02-20 |
| 3 | 2 | 2025-03-10 |

| Id | BestellingId | ProductId | Aantal |
| -- | ---------- | --------- | ------ |
| 1 | 1 | 1 | 1 |
| 2 | 1 | 3 | 2 |
| 3 | 2 | 2 | 1 |
| 4 | 3 | 1 | 2 |

### De generieke Repository Interface en Implementatie

De interface **IGenericRepository<TEntity>** en klasse **GenericRepository<TEntity>** zijn reeds aangemaakt in de map **Repositories**. Gebruik dezelfde implementatie als in oefening 07_01.

```csharp
// IGenericRepository<TEntity> — in map Repositories
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

```csharp
// GenericRepository<TEntity> — in map Repositories
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IModel
{
    protected readonly ElektroniXContext _context;

    public GenericRepository(ElektroniXContext context)
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

### De specifieke Klant Repository Interface

Maak een nieuwe interface **IKlantRepository** in de map **Repositories** die overerft van `IGenericRepository<Klant>`. Deze interface voegt één gespecialiseerde methode toe.

```csharp
using WebApi.Models;

namespace WebApi.Repositories;

public interface IKlantRepository : IGenericRepository<Klant>
{
    Task<Klant?> GetKlantMetBestellingenAsync(int klantId);
}
```

- `GetKlantMetBestellingenAsync` — haalt één klant op inclusief alle bestellingen, alle orderlijnen in die bestellingen, en de producten in die orderlijnen in één database-query.

### De specifieke Klant Repository Implementatie

Maak een klasse **KlantRepository** in de map **Repositories** die overerft van `GenericRepository<Klant>` en de `IKlantRepository`-interface implementeert.

De repository moet:
- de `DbContext` doorgeven aan de base constructor (`base(context)`);
- alle CRUD-methodes **niet** opnieuw implementeren — deze komen automatisch van `GenericRepository<Klant>`;
- de gespecialiseerde methode asynchroon implementeren met `.Include(k => k.Bestellingen)`, gevolgd door `.ThenInclude(b => b.OrderLijnen)`, en dan `.ThenInclude(ol => ol.Product)` om drie levels diep te navigeren;
- de `-Async` suffix gebruiken voor de namen van alle asynchrone methodes;
- de `protected _context` uit de basisklasse gebruiken om queries uit te voeren;
- `null` teruggeven als de klant niet bestaat (geen 404 in de repository);
- lege lijsten teruggeven wanneer er geen bestellingen zijn (geen null).

```csharp
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class KlantRepository : GenericRepository<Klant>, IKlantRepository
{
    public KlantRepository(ElektroniXContext context) : base(context) { }

    public async Task<Klant?> GetKlantMetBestellingenAsync(int klantId)
    {
        return await _context.Klanten
            .Include(k => k.Bestellingen)
                .ThenInclude(b => b.OrderLijnen)
                    .ThenInclude(ol => ol.Product)
            .FirstOrDefaultAsync(k => k.Id == klantId);
    }
}
```

### Dependency Injection

Registreer de DbContext en UnitOfWork in `Program.cs`:

```csharp
// Registreer de DbContext met de PostgreSQL-provider
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<ElektroniXContext>(options =>
    options.UseNpgsql(connectionString));

// Registreer UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
```

De controllers moeten de `IUnitOfWork` ontvangen via de constructor (geen `new` in de Controller).
