# 07_03

## Leerdoel

Na deze oefening kan je het Unit of Work-patroon implementeren met lazy-loaded repositories en een centrale `SaveChangesAsync`-methode.

Je leert hoe je een `IUnitOfWork`-interface definieert met zowel generieke als specifieke repository-properties, hoe je lazy loading gebruikt om repositories pas aan te maken op het moment dat ze nodig zijn, en hoe je alle database-wijzigingen atomic (alles of niets) in één transactie wegschrijft.

## Opdracht

De webshop **ElektroniX** wil haar producten en bestellingen beheren via één centrale toegangspoort. In plaats van elke repository apart te injecteren in de controller, wil men het Unit of Work-patroon gebruiken zodat alle repositories beheerd worden door één object en alle database-wijzigingen binnen één enkele transactie gebeuren.

Jouw taak is om de `IUnitOfWork`-interface en `UnitOfWork`-klasse te implementeren met lazy-loaded repositories, en een controller te bouwen die het Unit of Work gebruikt.

### De Modellen

#### Klant Model

Maak een Modelklasse `Klant` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de klant |
| Naam | string | De achternaam van de klant |
| Voornaam | string | De voornaam van de klant |
| Email | string | Het e-mailadres van de klant |

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

| Id | Naam | Prijs | Voorraad |
| -- | ---- | ----- | -------- |
| 1 | Laptop Pro | 2499.00 | 15 |
| 2 | Monitor 4K | 899.00 | 30 |
| 3 | Toetsenbord | 149.00 | 50 |

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

### De UnitOfWork Interface

Maak een nieuwe interface **IUnitOfWork** in de map **Data** met volgende definitie:

```csharp
using WebApi.Models;

namespace WebApi.Repositories;

public interface IUnitOfWork
{
    // Generieke repositories voor entiteiten die enkel basis-CRUD nodig hebben
    IGenericRepository<Klant> KlantRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }

    // De centrale Save methode (asynchroon)
    Task<int> SaveChangesAsync();
}
```

Deze interface definieert:
- `KlantRepository` — een generieke repository voor de `Klant`-entiteit;
- `ProductRepository` — een generieke repository voor de `Product`-entiteit;
- `SaveChangesAsync` — de centrale methode om alle wijzigingen atomic weg te schrijven.

### De UnitOfWork Implementatie

Maak een klasse **UnitOfWork** in de map **Data** die de `IUnitOfWork`-interface implementeert.

De UnitOfWork moet:
- de `DbContext` ontvangen via constructor injection (geen `new` in de klasse);
- private fields gebruiken voor lazy loading van de repositories (initieel `null`);
- lazy loading toepassen met de null-coalescing assignment operator (`??=`) — repositories worden pas aangemaakt op het moment dat ze voor het eerst worden opgevraagd;
- de `protected _context` uit de basisklasse gebruiken om nieuwe repository-instanties aan te maken;
- de `SaveChangesAsync`-methode doorgeven aan de DbContext.

```csharp
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ElektroniXContext _context;

    // Private fields voor de repositories (voor lazy loading)
    private IGenericRepository<Klant>? _klantRepository;
    private IGenericRepository<Product>? _productRepository;

    public UnitOfWork(ElektroniXContext context)
    {
        _context = context;
    }

    // Lazy Loading properties: Als een repo null is, maak hem dan aan.
    public IGenericRepository<Klant> KlantRepository =>
        _klantRepository ??= new GenericRepository<Klant>(_context);

    public IGenericRepository<Product> ProductRepository =>
        _productRepository ??= new GenericRepository<Product>(_context);

    // De centrale plek waar SaveChangesAsync wordt aangeroepen
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
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
