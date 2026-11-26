# 11_01

## Leerdoel

Na deze oefening kan je met NUnit een kleine methode testen volgens het Arrange-Act-Assert-principe en meerdere invoerwaarden met `[TestCase]` controleren.

**Moeilijkheid: gemakkelijk.**

## Opdracht

Een fietsenwinkel wil de prijs van een verhuur snel kunnen berekenen. Maak een klassebibliotheek met namespace `VerhuurApp` en een klasse `VerhuurCalculator`.

Voorzie de publieke methode:

```csharp
decimal BerekenPrijs(decimal dagprijs, int aantalDagen)
```

De methode retourneert `dagprijs × aantalDagen`. Een dagprijs van nul of hoger en een aantal dagen van nul of hoger zijn toegestaan. Als een van beide waarden negatief is, gooit de methode een `ArgumentOutOfRangeException`. De invoer wordt niet afgerond.

Maak in een apart NUnit-testproject `VerhuurCalculatorTests` en test de klasse met Arrange, Act en Assert. Gebruik `[TestCase]` voor ten minste de volgende situaties:

| Dagprijs | Aantal dagen | Verwacht resultaat |
| ---: | ---: | ---: |
| 12.50 | 1 | 12.50 |
| 12.50 | 4 | 50.00 |
| 0.00 | 3 | 0.00 |
| 12.50 | 0 | 0.00 |

Test daarnaast afzonderlijk dat een negatieve dagprijs en een negatief aantal dagen elk een `ArgumentOutOfRangeException` veroorzaken. Iedere test moet zelfstandig uitvoerbaar zijn en de uitkomst daadwerkelijk controleren met een assert.
