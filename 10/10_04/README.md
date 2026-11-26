# 10_04

## Leerdoel

Na deze oefening kan je Write-DTO's, Data Annotations, handmatige bedrijfsvalidatie en DTO-mapping combineren voor het aanmaken en wijzigen van records, terwijl alleen toegestane gegevens via de API te bepalen zijn.

**Moeilijkheid: moeilijk.**

## Opdracht

Een makerspace beheert apparatuur en reserveringen. Bouw een ASP.NET Core Web API met de volgende gegevens:

- `Apparaat`: `Id` (`int`), `Naam` (`string`), `Dagprijs` (`decimal`), `Beschikbaar` (`bool`).
- `Reservering`: `Id` (`int`), `ApparaatId` (`int`), `Klantnaam` (`string`), `AantalDagen` (`int`).

De applicatie start met apparaat ID `1` (`3D-printer`, dagprijs `25.00`, beschikbaar) en apparaat ID `2` (`Lasersnijder`, dagprijs `40.00`, beschikbaar), en zonder reserveringen.

Maak `ReserveringWriteDto` met uitsluitend `ApparaatId`, `Klantnaam` en `AantalDagen`. Maak `ReserveringDto` met `Id` (`int`), `ApparaatId` (`int`), `ApparaatNaam` (`string`), `Dagprijs` (`decimal`), `Klantnaam` (`string`), `AantalDagen` (`int`) en `TotaalPrijs` (`decimal`). Accepteer of retourneer geen entiteiten rechtstreeks.

Gebruik Data Annotations: `Klantnaam` is verplicht en 2–60 tekens lang; `AantalDagen` ligt tussen 1 en 14; `ApparaatId` moet positief zijn. Voer daarnaast handmatige validatie uit voor de regels dat het apparaat bestaat en beschikbaar is. Bij een mislukte validatie geeft de API status `400` en verandert er niets aan de reserveringen of de beschikbaarheid van apparaten.

Voorzie in `ReserveringenController`:

| Methode en route | Gedrag |
| --- | --- |
| `POST /api/reserveringen` | Maakt alleen bij geldige invoer een reservering aan. Geeft status `201` en `ReserveringDto` terug. Het gekozen apparaat wordt daarna niet meer als beschikbaar beschouwd. |
| `GET /api/reserveringen/{id}` | Geeft status `200` met `ReserveringDto`, of status `404` als de reservering niet bestaat. |
| `PUT /api/reserveringen/{id}` | Werkt bij een bestaande reservering de klantnaam, het aantal dagen en het apparaat bij. Geeft status `204`, of `404` als de reservering niet bestaat. |

Voor een succesvolle POST of PUT bevat de DTO de naam en dagprijs van het gekozen apparaat; `TotaalPrijs` is `Dagprijs × AantalDagen`. Bij PUT blijft het ID van de reservering gelijk. Het huidige apparaat van die reservering mag bij dezelfde PUT opnieuw gekozen worden, ook al is dit niet beschikbaar voor andere reserveringen. Een ander apparaat kan alleen worden gekozen als het bestaat en beschikbaar is. Als PUT faalt door een ongeldige body, onbekend apparaat of niet-beschikbaar apparaat, blijven zowel de reservering als de beschikbaarheid van alle apparaten ongewijzigd. Na een succesvolle wijziging wordt het oude apparaat weer beschikbaar als geen andere reservering het gebruikt; het nieuwe apparaat wordt niet beschikbaar. Een niet-bestaand reserverings-ID geeft `404` en verandert geen gegevens.

Bij een aanvraag die zowel een onbekend reserverings-ID als ongeldige invoer heeft, moet de API `404` teruggeven. ID's van nieuwe reserveringen zijn uniek en positief. De gegevensbron moet wijzigingen tijdens de levensduur van de applicatie bewaren. De interne opslag, validatiestructuur en mapping zijn vrij te kiezen; het beschreven HTTP- en state-gedrag is leidend.
