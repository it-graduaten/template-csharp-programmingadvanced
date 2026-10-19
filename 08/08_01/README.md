# 08_01

## Leerdoel

Na deze oefening kan je een gespecialiseerde repository-methode schrijven die gebruikmaakt van `.Include()` om gerelateerde entiteiten in één database-query op te halen.

Je leert hoe je het N+1 query probleem voorkomt door Eager Loading toe te passen met de `.Include()`-methode, zodat je gerelateerde data in één roundtrip naar de database ophaalt in plaats van meerdere losse queries.

## Opdracht

De fietsenwinkel **Fietsspecialist Gent** wil haar bestellingen-API verbeteren. Momenteel haalt hun controller handmatig de bijbehorende klant op voor elke bestelling, wat leidt tot het N+1 query probleem. Jouw taak is om een gespecialiseerde repository-methode te bouwen die de bestelling én de klant in één keer ophaalt.

### Het Klant Model

Maak een Modelklasse `Klant` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de klant |
| Naam | string | De achternaam van de klant |
| Voornaam | string | De voornaam van de klant |
| Email | string | Het e-mailadres van de klant |

Het model moet overerven van de `IModel`-interface.

### Het Bestelling Model

Maak een Modelklasse `Bestelling` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de bestelling |
| KlantId | int | De FK naar de klant |
| Klant | Klant? | Navigation Property naar de klant |
| BestelDatum | DateTime | De datum waarop de bestelling werd geplaatst |

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
    }
}
```

### Seed data toevoegen

Voeg de volgende seed data toe in de `OnModelCreating`-methode van de context:

| Id | Naam | Voornaam | Email |
| -- | ---- | -------- | ----- |
| 1 | Van Der Neffe | Leon | leon.vanderneffe@email.be |
| 2 | Van De Kasseinen | Firmin | firmin.vande.kasseinen@email.be |
| 3 | Kiekeboe | Marcel | marcel.kiekeboe@email.be |

| Id | KlantId | BestelDatum |
| -- | ------- | ----------- |
| 1 | 1 | 2025-01-15 |
| 2 | 1 | 2025-02-20 |
| 3 | 2 | 2025-03-10 |

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
    protected readonly FietsCatalogusContext _context;

    public GenericRepository(FietsCatalogusContext context)
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

### De specifieke Bestelling Repository Interface

Maak een nieuwe interface **IBestellingRepository** in de map **Repositories** die overerft van `IGenericRepository<Bestelling>`. Deze interface voegt één gespecialiseerde methode toe.

```csharp
using WebApi.Models;

namespace WebApi.Repositories;

public interface IBestellingRepository : IGenericRepository<Bestelling>
{
    Task<Bestelling?> GetBestellingMetKlantAsync(int id);
}
```

- `GetBestellingMetKlantAsync` — haalt één bestelling op inclusief de bijbehorende klant in één database-query.

### De specifieke Bestelling Repository Implementatie

Maak een klasse **BestellingRepository** in de map **Repositories** die overerft van `GenericRepository<Bestelling>` en de `IBestellingRepository`-interface implementeert.

De repository moet:
- de `DbContext` doorgeven aan de base constructor (`base(context)`);
- alle CRUD-methodes **niet** opnieuw implementeren — deze komen automatisch van `GenericRepository<Bestelling>`;
- de gespecialiseerde methode asynchroon implementeren met behulp van `.Include(b => b.Klant)` om de klant mee op te halen in één query;
- de `-Async` suffix gebruiken voor de namen van alle asynchrone methodes;
- de `protected _context` uit de basisklasse gebruiken om queries uit te voeren;
- `null` teruggeven als de bestelling niet bestaat (geen 404 in de repository).

```csharp
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class BestellingRepository : GenericRepository<Bestelling>, IBestellingRepository
{
    public BestellingRepository(FietsCatalogusContext context) : base(context) { }

    public async Task<Bestelling?> GetBestellingMetKlantAsync(int id)
    {
        return await _context.Bestellingen
            .Include(b => b.Klant)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}
```

### Dependency Injection

Registreer de DbContext en UnitOfWork in `Program.cs`:

```csharp
// Registreer de DbContext met de PostgreSQL-provider
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<FietsCatalogusContext>(options =>
    options.UseNpgsql(connectionString));

// Registreer UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
```

De controllers moeten de `IUnitOfWork` ontvangen via de constructor (geen `new` in de Controller).
