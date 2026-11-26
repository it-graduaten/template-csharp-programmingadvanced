# 11_02

## Leerdoel

Na deze oefening kan je NUnit-unit-tests schrijven voor een klasse met meerdere bedrijfsregels, grenswaarden en foutscenario's. Je test verschillende datasets zonder afhankelijk te zijn van externe systemen.

**Moeilijkheid: gemiddeld.**

## Opdracht

Een bibliotheek wil boetes voor te laat ingeleverde materialen berekenen. Maak in een klassebibliotheek met namespace `BibliotheekApp` de klasse `BoeteCalculator`.

Voorzie de publieke methode:

```csharp
decimal BerekenBoete(int dagenTeLaat, bool isNaslagwerk)
```

De methode berekent de boete volgens deze regels:

- Een gewoon materiaal kost € 0,50 per dag te laat.
- Een naslagwerk kost € 1,25 per dag te laat.
- De boete is nooit hoger dan € 20,00.
- Bij nul dagen te laat is de boete € 0,00.
- Een negatief aantal dagen veroorzaakt een `ArgumentOutOfRangeException`.

Maak in een afzonderlijk NUnit-testproject de klasse `BoeteCalculatorTests`. Gebruik tests met duidelijke namen en Arrange-Act-Assert. Gebruik `[TestCase]` waar meerdere waarden dezelfde regel controleren. Test ten minste:

| Dagen te laat | Naslagwerk | Verwachte boete |
| ---: | :---: | ---: |
| 0 | nee | 0.00 |
| 3 | nee | 1.50 |
| 3 | ja | 3.75 |
| 50 | nee | 20.00 |
| 50 | ja | 20.00 |

Voeg een test toe die controleert dat een negatieve invoer de genoemde exception veroorzaakt. Elke test moet geïsoleerd uitvoerbaar zijn en mag niet afhankelijk zijn van de volgorde waarin tests draaien.
