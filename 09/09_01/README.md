# 09_01

## Leerdoel

Na deze oefening kan je een read-DTO gebruiken om te bepalen welke gegevens een GET-endpoint aan een client terugstuurt. Je oefent met het omzetten van een entiteit naar een eenvoudig API-contract.

**Moeilijkheid: gemakkelijk.**

## Opdracht

Een bibliotheek wil haar boeken via een API tonen. De interne klasse `Boek` bevat ook `InterneNotitie` en `VoorraadLocatie`, maar deze gegevens mogen niet naar clients worden verstuurd.

Maak een ASP.NET Core Web API met een klasse `Boek` met properties `Id` (`int`), `Titel` (`string`), `Auteur` (`string`), `Isbn` (`string`), `InterneNotitie` (`string`) en `VoorraadLocatie` (`string`). Voorzie enkele vaste boeken als gegevensbron; een database is niet vereist.

Maak een read-DTO `BoekDto` met uitsluitend `Id` (`int`), `Titel` (`string`), `Auteur` (`string`) en `Isbn` (`string`). De DTO mag geen verwijzing naar `Boek` bevatten.

Voorzie in `BoekenController` de volgende endpoints:

| Methode en route | Gedrag |
| --- | --- |
| `GET /api/boeken` | Geeft status `200` en een JSON-array met alle boeken als `BoekDto`. Een lege bron geeft een lege array terug. |
| `GET /api/boeken/{id}` | Geeft status `200` en één `BoekDto` als het boek bestaat; anders status `404`. |

De JSON-objecten bevatten de properties `id`, `titel`, `auteur` en `isbn` (JSON-hoofdlettergebruik mag van de standaardinstellingen afhangen). `InterneNotitie` en `VoorraadLocatie` mogen in geen enkele response voorkomen. De gegevens die de endpoints teruggeven moeten uit dezelfde bron komen, zodat beide routes dezelfde boeken beschrijven.

Je mag de omzetting handmatig of met een mapper uitvoeren. De opdracht schrijft geen interne architectuur of mapperbibliotheek voor.
