# 07_01

## Leerdoel

Na deze oefening kan je een generieke repository-implementatie creëren met C# Generics en de `IModel`-interface.

Je leert hoe je een generieke interface `IGenericRepository<TEntity>` maakt met een type-constraint, hoe je een generieke klasse `GenericRepository<TEntity>` implementeert die alle basis-CRUD-operaties ondersteunt, en hoe je dit combineert met de `IModel`-interface om te garanderen dat alle entiteiten een `Id`-property hebben.

## Opdracht

De fietsenwinkel **Fietsspecialist Gent** wil haar fietscatalogus-API migreren van een in-memory lijst naar een echte PostgreSQL-database met Entity Framework Core. Om code-duplicatie te vermijden, wil men een generieke repository gebruiken die bruikbaar is voor elke entiteit.

Jouw taak is om de `IModel`-interface aan te maken, de generieke repository-interface en -implementatie te bouwen, en één model te laten inheriten van `IModel`.

### Het Fiets Model

Maak een Modelklasse `Fiets` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de fiets |
| Merk | string | Het merk van de fiets |
| Type | string | Het type fiets (bijv. "Mountainbike", "Racefiets", "Stadsfiets") |
| Kleur | string | De kleur van de fiets |
| Prijs | decimal | De prijs van de fiets |
| Voorraad | int | Het aantal beschikbare stuks op voorraad |

Het model moet overerven van de `IModel`-interface.

### De IModel Interface

Maak een nieuwe interface **IModel** in de map **Models** met de volgende definitie:

```csharp
namespace WebApi.Models;

public interface IModel
{
    int Id { get; set; }
}
```

Alle modellen in de applicatie moeten deze interface implementeren.

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
    }
}
```

### Seed data toevoegen

Voeg de volgende seed data toe in de `OnModelCreating`-methode van de context:

| Id | Merk | Type | Kleur | Prijs | Voorraad |
| -- | ---- | ---- | ----- | ----- | -------- |
| 1 | Trek | Mountainbike | Zwart | 1200.00 | 5 |
| 2 | Specialized | Racefiets | Rood | 2500.00 | 3 |
| 3 | Gazelle | Stadsfiets | Blauw | 800.00 | 12 |
| 4 | Giant | Mountainbike | Groen | 1500.00 | 7 |
| 5 | Koga | Stadsfiets | Wit | 950.00 | 8 |

### De generieke Repository Interface

Maak een nieuwe map genaamd **Repositories**. Voeg een interface toe genaamd **IGenericRepository.cs** met volgende definitie:

```csharp
using WebApi.Models;

namespace WebApi.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class, IModel
{
    // C - Create
    void Add(TEntity entity);

    // R - Read (All)
    Task<IEnumerable<TEntity>> GetAllAsync();

    // R - Read (Single)
    Task<TEntity?> GetByIdAsync(int id);

    // U - Update
    void Update(TEntity entity);

    // D - Delete
    void Delete(TEntity entity);

    // Controleer of een item bestaat
    Task<bool> ExistsAsync(int id);

    // Haal alle bestaande Id's op
    Task<int[]> GetExistingIdsAsync();
}
```

Deze interface gebruikt de type-parameter `TEntity` met twee constraints:
- `where TEntity : class` — zorgt dat TEntity een referentietype is;
- `where TEntity : IModel` — zorgt dat TEntity een Id-property heeft.

### De generieke Repository Implementatie

Maak in dezelfde map **Repositories** een klasse genaamd **GenericRepository.cs** die de `IGenericRepository<TEntity>`-interface implementeert.

De repository moet:
- de `DbContext` ontvangen via constructor injection (geen `new` in de klasse);
- de `_context` dependency markeren als `protected readonly` zodat overervende klassen toegang hebben;
- alle CRUD-operaties uitvoeren met behulp van `_context.Set<TEntity>()` in plaats van een specifieke DbSet;
- de `-Async` suffix gebruiken voor de namen van alle asynchrone methodes;
- de `Add`, `Update` en `Delete` methodes **niet** asynchroon maken (geen `Task` return type) — ze zijn puur voor het toevoegen van wijzigingen aan de Change Tracker;
- correct omgaan met niet-bestaande entiteiten bij `GetByIdAsync` (geef `null` terug als de entiteit niet bestaat).

```csharp
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

### Dependency Injection

Registreer de DbContext in `Program.cs` met `AddDbContext` en koppel deze aan de PostgreSQL-provider (Npgsql). Gebruik de connection string met naam **PostgresConnection** uit `appsettings.json`.
