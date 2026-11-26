# 11_03

## Leerdoel

Na deze oefening kan je met Moq afhankelijkheden vervangen door voorspelbare mocks en met NUnit zowel de uitkomst als relevante interacties van een controller testen.

**Moeilijkheid: gemiddeld.**

## Opdracht

Een bezorgdienst toont de status van een pakket. Maak een ASP.NET Core-project met namespace `PakketApi` en een controller `PakkettenController`. De controller krijgt via de constructor een `IPakketRepository`.

Definieer in namespace `PakketApi`:

- `Pakket` met `int Id` en `string Status`;
- `IPakketRepository` met `Task<Pakket?> ZoekOpIdAsync(int id)`.

Voorzie in `PakkettenController` de publieke methode `Task<ActionResult<string>> GetStatus(int id)` en route `GET /api/pakketten/{id}/status`. Als de repository een pakket teruggeeft, is het antwoord status `200` met alleen de status als tekst. Als de repository `null` teruggeeft, is het antwoord status `404` zonder body.

Maak een NUnit-testklasse `PakkettenControllerTests`. Gebruik Moq om `IPakketRepository` te mocken; tests mogen geen echte opslag of netwerk gebruiken. Test minimaal:

1. Een bestaand pakket retourneert status `200` en de verwachte statuswaarde.
2. Een onbekend pakket retourneert status `404`.
3. In beide gevallen wordt `ZoekOpIdAsync` precies eenmaal aangeroepen met het aangevraagde ID.

De tests moeten de controller rechtstreeks aanroepen en het publieke resultaat en de mockinteractie controleren. Geef de mock per test het benodigde antwoord; tests mogen niet van elkaars instellingen of uitvoervolgorde afhangen.
