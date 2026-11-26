# 09_03

## Leerdoel

Na deze oefening kan je een platte read-DTO samenstellen uit meerdere gerelateerde entiteiten en berekende gegevens. Je oefent met het scheiden van het API-contract van de interne objectstructuur.

**Moeilijkheid: gemiddeld.**

## Opdracht

Een verhuurbedrijf wil per reservatie een compact overzicht tonen. Maak een ASP.NET Core Web API met de entiteiten `Klant` (`Id`: `int`, `Voornaam`: `string`, `Familienaam`: `string`), `Reservatie` (`Id`: `int`, `KlantId`: `int`, `Klant`: `Klant`, `Regels`: lijst van `Reservatieregel`) en `Reservatieregel` (`Id`: `int`, `ReservatieId`: `int`, `MateriaalNaam`: `string`, `Aantal`: `int`, `Dagprijs`: `decimal`). Voorzie een reproduceerbare gegevensbron met reservaties, klanten en regels; een database is niet vereist.

Maak de DTO’s:

- `ReservatieOverzichtDto`: `Id` (`int`), `KlantNaam` (`string`), `TotaalPrijs` (`decimal`) en `Regels` (lijst van `ReservatieregelDto`).
- `ReservatieregelDto`: `MateriaalNaam` (`string`), `Aantal` (`int`), `Dagprijs` (`decimal`) en `RegelTotaal` (`decimal`).

Voor de berekening geldt `RegelTotaal = Aantal × Dagprijs` en `TotaalPrijs` is de som van alle regeltotalen. `KlantNaam` is de voornaam, gevolgd door één spatie en de familienaam. Gebruik decimalen voor geldbedragen. De DTO’s bevatten geen entiteiten en geen navigatie terug naar de reservatie.

Voorzie in `ReservatiesController`:

| Methode en route | Gedrag |
| --- | --- |
| `GET /api/reservaties/{id}/overzicht` | Geeft status `200` met precies één `ReservatieOverzichtDto` en alle bovenstaande waarden correct berekend; bij een onbekend ID status `404`. |

Een reservatie zonder regels geeft een lege lijst en `TotaalPrijs` van `0`. Het endpoint mag geen gegevens van een andere reservatie in het resultaat opnemen. De interne mapping mag handmatig of met een mapper gebeuren; het publieke responsecontract blijft zoals hierboven beschreven.
