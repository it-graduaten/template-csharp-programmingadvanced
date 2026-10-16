# 07_04

## Leerdoel

Na deze oefening kan je een complete CRUD-API bouwen die het Unit of Work-patroon combineert met zowel generieke als specifieke repositories, en alle database-wijzigingen atomic wegschrijft via één centrale `SaveChangesAsync`-aanroep.

Je leert hoe je een specifieke repository met gespecialiseerde methodes integreert in het Unit of Work-patroon, hoe je meerdere entiteiten in één transactie aanmaakt (bijv. bestelling én orderlijnen), en hoe je de controller volledig ontkoppelt van de datalaag door enkel via `IUnitOfWork` te communiceren.

## Opdracht

De webshop **ElektroniX** wil haar bestellingen-API bouwen voor het beheren van producten en bestellingen. Men wil alle datatoegang laten verlopen via het Unit of Work-patroon zodat controllers enkel via één centrale toegangspoort communiceren met de database. Bestellingen moeten samen met hun orderlijnen atomic (alles of niets) worden opgeslagen.

Jouw taak is om de modellen, repositories, Unit of Work, en controllers te implementeren met een volledige CRUD-API voor producten en bestellingen.

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

#### Bestelling Model

Maak een Modelklasse `Bestelling` in de map `Models` met volgende Properties:

| Property | Type | Beschrijving |
| -------- | ---- | ------------ |
| Id | int | Unieke identificatie van de bestelling |
| KlantId | int | De FK naar de klant |
| Klant | Klant? | Navigation Property naar de klant |
| OrderLijnen | List<OrderLijn> | De orderlijnen van deze bestelling |

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
  - **Bestelling ↔ OrderLijn** (1:N): `BestellingId` als Foreign Key in OrderLijn, `OnDelete(DeleteBehavior.Restrict)`;
  - **Product ↔ OrderLijn** (1:N): `ProductId` als Foreign Key in OrderLijn;
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
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Producten");
            entity.Property(p => p.Naam).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Prijs).IsRequired().HasPrecision(18, 2);
        });

        modelBuilder.Entity<Bestelling>(entity =>
        {
            entity.ToTable("Bestellingen");
            entity.HasOne(b => b.Klant)
                .WithMany(k => k.Bestellingen)
                .HasForeignKey(b => b.KlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OrderLijn>(entity =>
        {
            entity.ToTable("OrderLijnen");
            entity.HasOne(ol => ol.Bestelling)
                .WithMany(b => b.OrderLijnen)
                .HasForeignKey(ol => ol.BestellingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasOne(ol => ol.Product)
                .WithMany()
                .HasForeignKey(ol => ol.ProductId)
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
| 3 | Kiekeboe | Marcel | marcel.kiekeboe@email.be |

| Id | Naam | Prijs | Voorraad |
| -- | ---- | ----- | -------- |
| 1 | Laptop Pro | 2499.00 | 15 |
| 2 | Monitor 4K | 899.00 | 30 |
| 3 | Toetsenbord | 149.00 | 50 |

| Id | KlantId |
| -- | ------- |
| 1 | 1 |
| 2 | 2 |
| 3 | 3 |

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

Maak een nieuwe interface **IBestellingRepository** in de map **Repositories** die overerft van `IGenericRepository<Bestelling>`. Deze interface voegt één gespecialiseerde methode toe.

```csharp
using WebApi.Models;

namespace WebApi.Repositories;

public interface IBestellingRepository : IGenericRepository<Bestelling>
{
    Task<IEnumerable<Bestelling>> GetBestellingenByKlantAsync(int klantId);
}
```

- `GetBestellingenByKlantAsync` — filter bestellingen op klant (case-insensitive).

### De specifieke Bestelling Repository Implementatie

Maak een klasse **BestellingRepository** in de map **Repositories** die overerft van `GenericRepository<Bestelling>` en de `IBestellingRepository`-interface implementeert.

De repository moet:
- de `DbContext` doorgeven aan de base constructor (`base(context)`);
- alle CRUD-methodes **niet** opnieuw implementeren — deze komen automatisch van `GenericRepository<Bestelling>`;
- de gespecialiseerde methode asynchroon implementeren met de juiste EF Core async methodes;
- de `-Async` suffix gebruiken voor de namen van alle asynchrone methodes;
- de `protected _context` uit de basisklasse gebruiken om queries uit te voeren.

```csharp
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class BestellingRepository : GenericRepository<Bestelling>, IBestellingRepository
{
    public BestellingRepository(ElektroniXContext context) : base(context) { }

    public async Task<IEnumerable<Bestelling>> GetBestellingenByKlantAsync(int klantId)
    {
        return await _context.Bestellingen
            .Where(b => b.KlantId == klantId)
            .OrderByDescending(b => b.Id)
            .ToListAsync();
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
    // Specifieke repository omdat deze extra methoden heeft
    IBestellingRepository BestellingRepository { get; }

    // Generieke repositories voor entiteiten die enkel basis-CRUD nodig hebben
    IGenericRepository<Klant> KlantRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }
    IGenericRepository<OrderLijn> OrderLijnRepository { get; }

    // De centrale Save methode (asynchroon)
    Task<int> SaveChangesAsync();
}
```

Deze interface definieert:
- `BestellingRepository` — een specifieke repository voor de `Bestelling`-entiteit met gespecialiseerde methodes;
- `KlantRepository` — een generieke repository voor de `Klant`-entiteit;
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
    private IGenericRepository<Klant>? _klantRepository;
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

    // Voor de generieke repositories maken we direct een GenericRepository<T> aan
    public IGenericRepository<Klant> KlantRepository =>
        _klantRepository ??= new GenericRepository<Klant>(_context);

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

### De Product Controller

Maak een `ProductController` met volgende endpoints. Elke endpoint moet logging bevatten:

#### 1. Alle producten ophalen

Route: `GET /api/producten`

Geef alle producten terug als JSON met HTTP-statuscode **200 OK**.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request.

#### 2. Eén product ophalen op basis van de ID

Route: `GET /api/producten/{id}`

Vind het product met de gevraagde ID en geef het terug als JSON met HTTP-statuscode **200 OK**.

Als er geen product bestaat met de gevraagde ID, geef dan HTTP-statuscode **404 Not Found** terug zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Warning` als het product niet gevonden wordt.

#### 3. Een nieuw product aanmaken

Route: `POST /api/producten`

De client stuurt een product als JSON in de Request Body. ASP.NET Core zet deze automatisch om naar een `Product`-object via Model Binding.

Het endpoint moet:
1. Het product toevoegen via de Unit of Work (`_uow.ProductRepository.Add(product)`);
2. Alle wijzigingen atomic wegschrijven via de Unit of Work (`await _uow.SaveChangesAsync()`);
3. Het volledige product (inclusief de gegenereerde ID) terugsturen met HTTP-statuscode **201 Created**.

De `id` in de request body mag worden genegeerd; Entity Framework genereert de ID automatisch.

Voeg een logbericht van niveau `Information` toe bij het aanmaken van een product.

#### 4. Een product bijwerken

Route: `PUT /api/producten/{id}`

De routeparameter `{id}` stelt de product-ID voor. De client stuurt de nieuwe gegevens van het product als JSON in de Request Body via Model Binding.

Het endpoint moet:
1. Het product vinden met de gevraagde ID via de Unit of Work;
2. Als het product niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
3. Het product bijwerken via de Unit of Work (`_uow.ProductRepository.Update(product)`);
4. Alle wijzigingen atomic wegschrijven via de Unit of Work (`await _uow.SaveChangesAsync()`);
5. HTTP-statuscode **204 No Content** terugsturen zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Warning` als het product niet gevonden wordt.

#### 5. Een product verwijderen

Route: `DELETE /api/producten/{id}`

De routeparameter `{id}` stelt de product-ID voor.

Het endpoint moet:
1. Het product vinden met de gevraagde ID via de Unit of Work;
2. Als het product niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
3. Het product verwijderen via de Unit of Work (`_uow.ProductRepository.Delete(product)`);
4. Alle wijzigingen atomic wegschrijven via de Unit of Work (`await _uow.SaveChangesAsync()`);
5. HTTP-statuscode **204 No Content** terugsturen zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Error` als het product niet gevonden wordt.

### De Bestelling Controller

Maak een `BestellingController` met volgende endpoints. Elke endpoint moet logging bevatten:

#### 1. Alle bestellingen ophalen

Route: `GET /api/bestellingen`

Geef alle bestellingen terug als JSON met HTTP-statuscode **200 OK**.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request.

#### 2. Eén bestelling ophalen op basis van de ID

Route: `GET /api/bestellingen/{id}`

Vind de bestelling met de gevraagde ID en geef het terug als JSON met HTTP-statuscode **200 OK**.

Als er geen bestelling bestaat met de gevraagde ID, geef dan HTTP-statuscode **404 Not Found** terug zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Warning` als de bestelling niet gevonden wordt.

#### 3. Bestellingen ophalen op basis van de klant

Route: `GET /api/bestellingen/klant/{klantId}`

De routeparameter `{klantId}` stelt de klant-ID voor.

Zoek alle bestellingen van de gevraagde klant via de gespecialiseerde repository-methode (`_uow.BestellingRepository.GetBestellingenByKlantAsync(klantId)`) en geef ze terug als JSON met HTTP-statuscode **200 OK**.

Wordt er geen bestelling gevonden voor die klant, geef dan een lege JSON-lijst `[]` terug met HTTP-statuscode **200 OK** (geen 404 voor lege resultaten).

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request.

#### 4. Een nieuwe bestelling aanmaken (met orderlijnen)

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

#### 5. Een bestelling bijwerken

Route: `PUT /api/bestellingen/{id}`

De routeparameter `{id}` stelt de bestelling-ID voor. De client stuurt de nieuwe gegevens van de bestelling als JSON in de Request Body via Model Binding.

Het endpoint moet:
1. De bestelling vinden met de gevraagde ID via de Unit of Work;
2. Als de bestelling niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
3. Controleren of de klant bestaat via `_uow.KlantRepository.GetByIdAsync(bestelling.KlantId)` — als de klant niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
4. De bestelling bijwerken via de Unit of Work (`_uow.BestellingRepository.Update(bestelling)`);
5. Alle wijzigingen atomic wegschrijven via de Unit of Work (`await _uow.SaveChangesAsync()`);
6. HTTP-statuscode **204 No Content** terugsturen zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Warning` als de bestelling niet gevonden wordt.

#### 6. Een bestelling verwijderen

Route: `DELETE /api/bestellingen/{id}`

De routeparameter `{id}` stelt de bestelling-ID voor.

Het endpoint moet:
1. De bestelling vinden met de gevraagde ID via de Unit of Work;
2. Als de bestelling niet bestaat, HTTP-statuscode **404 Not Found** terugsturen zonder body;
3. De bestelling verwijderen via de Unit of Work (`_uow.BestellingRepository.Delete(bestelling)`);
4. Alle wijzigingen atomic wegschrijven via de Unit of Work (`await _uow.SaveChangesAsync()`);
5. HTTP-statuscode **204 No Content** terugsturen zonder body.

Voeg een logbericht van niveau `Information` toe bij het ontvangen van de request en een logbericht van niveau `Error` als de bestelling niet gevonden wordt.

### Dependency Injection

Registreer de DbContext, UnitOfWork en specifieke repository in `Program.cs`:

```csharp
// Registreer de DbContext met de PostgreSQL-provider
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<ElektroniXContext>(options =>
    options.UseNpgsql(connectionString));

// Registreer UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
```

De controllers moeten de `IUnitOfWork` ontvangen via de constructor (geen `new` in de Controller).

De controllers moeten ook `ILogger<T>` ontvangen via de constructor voor logging.
