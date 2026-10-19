# 08_04

## Leerdoel

Na deze oefening kan je een complete CRUD-API bouwen die het Unit of Work-patroon combineert met gespecialiseerde repositories voor eager loading, en het JSON circular reference probleem oplost.

Je leert hoe je het Unit of Work-patroon aanpast om specifieke repositories in plaats van generieke repositories te gebruiken, hoe je een BestellingController bouwt met zowel basis-CRUD als eager-loading endpoints, en hoe je de JSON-serializer configureert om circular references te negeren.

## Opdracht

De webshop **ElektroniX** wil haar bestellingen-API volledig herbouwen. Ze hebben nu de kennis van Eager Loading en willen alle datatoegang laten verlopen via het Unit of Work-patroon. Ze willen endpoints voor zowel basis-CRUD als geavanceerde queries met geneste data. Daarnaast moeten ze het JSON circular reference probleem oplossen dat optreedt wanneer ze een bestelling ophalen met klant én orderlijnen met producten.

Jouw taak is om de modellen, repositories, Unit of Work, controllers, en JSON-configuratie te implementeren.

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

Maak een nieuwe map genaamd **Data**. Voeg een klasse genaamd **ElektroniXContext** toe die overerft van `DbContext`.

De context moet:
- een constructor hebben die `DbContextOptions<ElektroniXContext>` accepteert en doorgeeft aan de basisklasse;
- vier `DbSet<T>`-properties bevatten: **Klanten**, **Producten**, **Bestellingen**, **OrderLijnen**;
- de Fluent API (`OnModelCreating`) overschrijven om tabelnamen en eigenschappen te configureren;
- de relaties configureren met de Fluent API:
  - **Klant ↔ Bestelling** (1:N): `KlantId` als Foreign Key in Bestelling, `OnDelete(DeleteBehavior.Restrict)`;
  - **Bestelling ↔ OrderLijn** (1:N): `BestellingId` als Foreign Key in OrderLijn, `OnDelete(DeleteBehavior.Cascade)`;
  - **Product ↔ OrderLijn** (1:N): `ProductId` als Foreign Key in OrderLijn, `OnDelete(DeleteBehavior.Restrict)`;
- de namespace **WebApi.Data** gebruiken.

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

### De specifieke Bestelling Repository Interface

Maak een nieuwe interface **IBestellingRepository** in de map **Repositories** die overerft van `IGenericRepository<Bestelling>`. Deze interface voegt twee gespecialiseerde methodes toe.

```csharp
using WebApi.Models;

namespace WebApi.Repositories;

public interface IBestellingRepository : IGenericRepository<Bestelling>
{
    Task<Bestelling?> GetBestellingMetKlantAsync(int id);
    Task<Bestelling?> GetBestellingMetDetailsAsync(int id);
}
```

Methodes:
- `GetBestellingMetKlantAsync` — haalt één bestelling op inclusief de bijbehorende klant in één database-query;
- `GetBestellingMetDetailsAsync` — haalt één bestelling op inclusief de klant, alle orderlijnen, en de producten in die orderlijnen in één database-query.

### De specifieke Bestelling Repository Implementatie

Maak een klasse **BestellingRepository** in de map **Repositories** die overerft van `GenericRepository<Bestelling>` en de `IBestellingRepository`-interface implementeert.

De repository moet:
- de `DbContext` doorgeven aan de base constructor (`base(context)`);
- alle CRUD-methodes **niet** opnieuw implementeren — deze komen automatisch van `GenericRepository<Bestelling>`;
- beide gespecialiseerde methodes asynchroon implementeren met de juiste `.Include()` en `.ThenInclude()` methodes;
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
    public BestellingRepository(ElektroniXContext context) : base(context) { }

    public async Task<Bestelling?> GetBestellingMetKlantAsync(int id)
    {
        return await _context.Bestellingen
            .Include(b => b.Klant)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Bestelling?> GetBestellingMetDetailsAsync(int id)
    {
        return await _context.Bestellingen
            .Include(b => b.Klant)
            .Include(b => b.OrderLijnen)
                .ThenInclude(ol => ol.Product)
            .FirstOrDefaultAsync(b => b.Id == id);
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
- `null` teruggeven als de klant niet bestaat (geen 404 in de repository).

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

### De UnitOfWork Interface

Maak een nieuwe interface **IUnitOfWork** in de map **Data** met volgende definitie:

```csharp
namespace WebApi.Repositories;

public interface IUnitOfWork
{
    // Specifieke repositories omdat deze extra methoden hebben
    IBestellingRepository BestellingRepository { get; }
    IKlantRepository KlantRepository { get; }

    // Generieke repositories voor entiteiten die enkel basis-CRUD nodig hebben
    IGenericRepository<Product> ProductRepository { get; }
    IGenericRepository<OrderLijn> OrderLijnRepository { get; }

    // De centrale Save methode (asynchroon)
    Task<int> SaveChangesAsync();
}
```

Deze interface definieert:
- `BestellingRepository` — een specifieke repository voor de `Bestelling`-entiteit met gespecialiseerde Include-methodes;
- `KlantRepository` — een specifieke repository voor de `Klant`-entiteit met gespecialiseerde Include-methode;
- `ProductRepository` — een generieke repository voor de `Product`-entiteit;
- `OrderLijnRepository` — een generieke repository voor de `OrderLijn`-entiteit;
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
    private IBestellingRepository? _bestellingRepository;
    private IKlantRepository? _klantRepository;
    private IGenericRepository<Product>? _productRepository;
    private IGenericRepository<OrderLijn>? _orderLijnRepository;

    public UnitOfWork(ElektroniXContext context)
    {
        _context = context;
    }

    // Lazy Loading properties: Als een repo null is, maak hem dan aan.
    // Voor Bestelling gebruiken we de specifieke repository omdat deze extra methoden heeft
    public IBestellingRepository BestellingRepository =>
        _bestellingRepository ??= new BestellingRepository(_context);

    // Voor Klant gebruiken we de specifieke repository omdat deze extra methoden heeft
    public IKlantRepository KlantRepository =>
        _klantRepository ??= new KlantRepository(_context);

    // Voor de generieke repositories maken we direct een GenericRepository<T> aan
    public IGenericRepository<Product> ProductRepository =>
        _productRepository ??= new GenericRepository<Product>(_context);

    public IGenericRepository<OrderLijn> OrderLijnRepository =>
        _orderLijnRepository ??= new GenericRepository<OrderLijn>(_context);

    // De centrale plek waar SaveChangesAsync wordt aangeroepen
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
```

### De Bestelling Controller

Maak een `BestellingController` met volgende endpoints. Elke endpoint moet logging bevatten.

#### 1. Alle bestellingen ophalen

Route: `GET /api/bestellingen`

Geef alle bestellingen terug als JSON met HTTP-statuscode **200 OK**.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request.

#### 2. Eén bestelling ophalen op basis van de ID

Route: `GET /api/bestellingen/{id}`

Vind de bestelling met de gevraagde ID en geef het terug als JSON met HTTP-statuscode **200 OK**.

Als er geen bestelling bestaat met de gevraagde ID, geef dan HTTP-statuscode **404 Not Found** terug zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Warning` als de bestelling niet gevonden wordt.

#### 3. Een bestelling ophalen met klantgegevens

Route: `GET /api/bestellingen/{id}/details`

De routeparameter `{id}` stelt de bestelling-ID voor.

Vind de bestelling met de gevraagde ID inclusief de bijbehorende klant in één query via `_uow.BestellingRepository.GetBestellingMetKlantAsync(id)` en geef het terug als JSON met HTTP-statuscode **200 OK**.

Als er geen bestelling bestaat met de gevraagde ID, geef dan HTTP-statuscode **404 Not Found** terug zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Warning` als de bestelling niet gevonden wordt.

#### 4. Een bestelling ophalen met alle details (klant, orderlijnen, producten)

Route: `GET /api/bestellingen/{id}/volledig`

De routeparameter `{id}` stelt de bestelling-ID voor.

Vind de bestelling met de gevraagde ID inclusief de klant, alle orderlijnen, en de producten in die orderlijnen in één query via `_uow.BestellingRepository.GetBestellingMetDetailsAsync(id)` en geef het terug als JSON met HTTP-statuscode **200 OK**.

Als er geen bestelling bestaat met de gevraagde ID, geef dan HTTP-statuscode **404 Not Found** terug zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Warning` als de bestelling niet gevonden wordt.

#### 5. Alle bestellingen van een klant ophalen

Route: `GET /api/bestellingen/klant/{klantId}`

De routeparameter `{klantId}` stelt de klant-ID voor.

Zoek de klant inclusief alle bestellingen, orderlijnen, en producten in één query via `_uow.KlantRepository.GetKlantMetBestellingenAsync(klantId)` en geef het terug als JSON met HTTP-statuscode **200 OK**.

Wordt er geen klant gevonden voor die ID, geef dan HTTP-statuscode **404 Not Found** terug zonder body.

Wordt er geen bestelling gevonden voor die klant (maar de klant bestaat wel), geef dan een lege JSON-lijst `[]` terug met HTTP-statuscode **200 OK** (geen 404 voor lege resultaten).

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request.

#### 6. Een nieuwe bestelling aanmaken (met orderlijnen)

Route: `POST /api/bestellingen`

De client stuurt een bestelling met orderlijnen als JSON in de Request Body. ASP.NET Core zet deze automatisch om naar een `Bestelling`-object via Model Binding. De `Id` in de request body mag worden genegeerd; Entity Framework genereert de ID automatisch.

Het endpoint moet:
1. Controleren of de klant bestaat via `_uow.KlantRepository.GetByIdAsync(bestelling.KlantId)` — als de klant niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
2. Controleren of alle producten in de orderlijnen bestaan via `_uow.ProductRepository.GetByIdAsync(productId)` — als een product niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
3. De bestelling toevoegen via de Unit of Work (`_uow.BestellingRepository.Add(bestelling)`);
4. Alle wijzigingen atomic wegschrijven via de Unit of Work (`await _uow.SaveChangesAsync()`);
5. Het volledige product (inclusief de gegenereerde ID) terugsturen met HTTP-statuscode **201 Created**.

**Belangrijk**: de bestelling en al haar orderlijnen moeten binnen één enkele transactie worden weggeschreven. Als één van de controles faalt, moet er niets weggeschreven worden.

Voeg een logbericht van niveau `Information` toe bij het aanmaken van een bestelling.

#### 7. Een bestelling bijwerken

Route: `PUT /api/bestellingen/{id}`

De routeparameter `{id}` stelt de bestelling-ID voor. De client stuurt de nieuwe gegevens van de bestelling als JSON in de Request Body via Model Binding.

Het endpoint moet:
1. De bestelling vinden met de gevraagde ID via de Unit of Work;
2. Als de bestelling niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
3. Controleren of de klant bestaat via `_uow.KlantRepository.GetByIdAsync(bestelling.KlantId)` — als de klant niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
4. Controleren of de klantID in de request overeenkomt met de klantID van de gevonden bestelling — als ze niet overeenkomen, HTTP-statuscode **400 Bad Request** terugsturen met het bericht `"De ID in de URL komt niet overeen met het ID in de data."`;
5. De bestelling bijwerken via de Unit of Work (`_uow.BestellingRepository.Update(bestelling)`);
6. Alle wijzigingen atomic wegschrijven via de Unit of Work (`await _uow.SaveChangesAsync()`);
7. HTTP-statuscode **204 No Content** terugsturen zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Warning` als de bestelling niet gevonden wordt.

#### 8. Een bestelling verwijderen

Route: `DELETE /api/bestellingen/{id}`

De routeparameter `{id}` stelt de bestelling-ID voor.

Het endpoint moet:
1. De bestelling vinden met de gevraagde ID via de Unit of Work;
2. Als de bestelling niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
3. De bestelling verwijderen via de Unit of Work (`_uow.BestellingRepository.Delete(bestelling)`);
4. Alle wijzigingen atomic wegschrijven via de Unit of Work (`await _uow.SaveChangesAsync()`);
5. HTTP-statuscode **204 No Content** terugsturen zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Error` als de bestelling niet gevonden wordt.

### Het JSON Circular Reference Probleem

Wanneer je endpoint 4 (`GET /api/bestellingen/{id}/volledig`) aanroept, kan de JSON-serializer crashen door het circular reference probleem: de Bestelling verwijst naar de Klant, en de Klant verwijst naar Bestellingen, enzovoort.

Los dit op in `Program.cs` door de JSON-serializer te configureren om circular references te negeren:

```csharp
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
```

### Dependency Injection

Registreer de DbContext, UnitOfWork in `Program.cs`:

```csharp
// Registreer de DbContext met de PostgreSQL-provider
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<ElektroniXContext>(options =>
    options.UseNpgsql(connectionString));

// Registreer UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registreer JSON-serializer opties voor circular references
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
```

De controllers moeten de `IUnitOfWork` ontvangen via de constructor (geen `new` in de Controller).
