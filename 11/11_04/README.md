# 11_04

## Leerdoel

Na deze oefening kan je test-first een businessservice ontwerpen en implementeren, meerdere regels en grensgevallen met NUnit controleren en een dependency mocken om een service geïsoleerd te testen.

**Moeilijkheid: moeilijk.**

## Opdracht

Een evenement organiseert inschrijvingen met een beperkte capaciteit en een optionele korting. Maak een klassebibliotheek met namespace `EvenementApp` en een klasse `InschrijvingService`. De service ontvangt via de constructor een `IInschrijvingRepository` met de methode:

```csharp
int AantalInschrijvingenVoorEvenement(int evenementId)
```

Voorzie de methode:

```csharp
InschrijvingResultaat Beoordeel(int evenementId, int capaciteit, int aangevraagdAantal, bool heeftKortingscode)
```

`InschrijvingResultaat` bevat de properties `bool Goedgekeurd`, `int AantalToegekend` en `decimal TotaalPrijs`.

Pas de volgende afspraken toe:

- Een evenement-ID en capaciteit moeten positief zijn. `aangevraagdAantal` moet positief zijn. Bij een ongeldige waarde gooit `Beoordeel` een `ArgumentOutOfRangeException`.
- De service vraagt met het evenement-ID het huidige aantal inschrijvingen op via de repository.
- Als het huidige aantal kleiner is dan nul of groter is dan de opgegeven capaciteit, gooit de service een `InvalidOperationException`.
- Als de aanvraag de resterende capaciteit overschrijdt, wordt deze afgewezen: `Goedgekeurd` is `false`, `AantalToegekend` en `TotaalPrijs` zijn beide `0`.
- Anders wordt de aanvraag goedgekeurd en is `AantalToegekend` gelijk aan `aangevraagdAantal`.
- Een inschrijving kost € 30 per persoon. Met kortingscode geldt 10% korting op het totaal. `TotaalPrijs` is het bedrag na korting, zonder afronding.
- De repository wordt voor een geldige aanvraag precies eenmaal aangeroepen met het opgegeven evenement-ID. Bij ongeldige argumenten wordt de repository niet aangeroepen.

Maak in een afzonderlijk NUnit-testproject `InschrijvingServiceTests`. Gebruik Moq voor de repository en schrijf de tests volgens Arrange-Act-Assert. Schrijf eerst tests voor het gewenste gedrag en implementeer daarna de service. Test minimaal:

| Huidig aantal | Capaciteit | Aantal gevraagd | Kortingscode | Verwachting |
| ---: | ---: | ---: | :---: | --- |
| 0 | 20 | 2 | nee | Goedgekeurd; 2 toegekend; totaal 60.00 |
| 5 | 20 | 3 | ja | Goedgekeurd; 3 toegekend; totaal 81.00 |
| 18 | 20 | 3 | nee | Afgewezen; 0 toegekend; totaal 0.00 |
| 20 | 20 | 1 | ja | Afgewezen; 0 toegekend; totaal 0.00 |

Voeg ook tests toe voor een ongeldige invoerwaarde, een ongeldige repository-uitkomst en het aantal repository-aanroepen bij zowel succes als afwijzing. Iedere test moet eigen mocks en invoer gebruiken en afzonderlijk dezelfde uitkomst geven.
