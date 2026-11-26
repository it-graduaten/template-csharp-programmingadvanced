# 09_04

## Leerdoel

Na deze oefening kan je afzonderlijke read- en write-DTO’s ontwerpen voor een API met relaties, meerdere endpoints aanbieden met verschillende contracten en complexe gegevens omzetten naar een plat resultaat.

**Moeilijkheid: moeilijk.**

## Opdracht

Een opleidingscentrum wil cursussen en inschrijvingen beheren via een ASP.NET Core Web API. Maak een reproduceerbare gegevensbron met de volgende entiteiten:

- `Cursus`: `Id` (`int`), `Titel` (`string`), `Prijs` (`decimal`), `InternCommentaar` (`string`).
- `Deelnemer`: `Id` (`int`), `Naam` (`string`), `Email` (`string`), `Inschrijvingen` (lijst van `Inschrijving`).
- `Inschrijving`: `Id` (`int`), `DeelnemerId` (`int`), `CursusId` (`int`), `Cursus` (`Cursus`), `AantalPlaatsen` (`int`).

Deelnemer en cursus worden via een inschrijving gekoppeld. Voorzie minstens twee cursussen en twee deelnemers; zorg dat één deelnemer voor meerdere cursussen ingeschreven is en dat een cursus door meerdere deelnemers gevolgd kan worden.

### DTO’s en contracten

Maak deze DTO’s. Gebruik uitsluitend de genoemde properties; DTO’s mogen geen entiteiten bevatten.

| DTO | Properties |
| --- | --- |
| `CursusDto` | `Id` (`int`), `Titel` (`string`), `Prijs` (`decimal`) |
| `InschrijvingCreateDto` | `CursusId` (`int`), `AantalPlaatsen` (`int`) |
| `InschrijvingDto` | `CursusId` (`int`), `CursusTitel` (`string`), `AantalPlaatsen` (`int`), `TotaalPrijs` (`decimal`) |
| `DeelnemerDto` | `Id` (`int`), `Naam` (`string`), `Inschrijvingen` (lijst van `InschrijvingDto`) |

`TotaalPrijs` is `AantalPlaatsen × Cursus.Prijs`. `InternCommentaar` en het e-mailadres worden niet via deze endpoints teruggegeven. Berekeningen en mapping moeten correcte waarden opleveren, ongeacht hoe de relaties intern worden opgehaald.

### Endpoints

Implementeer in `CursussenController` en `DeelnemersController`:

| Methode en route | Gedrag |
| --- | --- |
| `GET /api/cursussen` | Status `200`; array van `CursusDto`. Een lege bron geeft `[]`. |
| `GET /api/deelnemers/{id}` | Status `200` met `DeelnemerDto`, inclusief alle inschrijvingen en berekende totalen; status `404` als de deelnemer niet bestaat. Een deelnemer zonder inschrijvingen heeft een lege lijst. |
| `POST /api/deelnemers/{id}/inschrijvingen` | Body is `InschrijvingCreateDto`. Bij geldige invoer wordt de inschrijving aan de deelnemer gekoppeld en geeft de API status `201` met de nieuwe `InschrijvingDto`. |

Voor de POST-route zijn `AantalPlaatsen` groter dan nul, een bestaande deelnemer en een bestaande cursus vereist. Ontbreekt de deelnemer of cursus, dan is het resultaat `404`; is `AantalPlaatsen` ongeldig, dan is het resultaat `400`. Een fout verandert de gegevensbron niet. Een geslaagde inschrijving is onmiddellijk zichtbaar in een volgende GET voor de deelnemer. ID’s en gevoelige of interne velden mogen niet door de client worden ingesteld en mogen niet in responses verschijnen.

Het publieke contract en het beschreven gedrag zijn leidend. Je mag de gegevensbron, mapping en interne indeling zelf kiezen; een specifieke database, mapperbibliotheek of klasse-indeling is niet vereist.
