# 10_03

## Leerdoel

Na deze oefening kan je een write-DTO mappen naar een read-DTO en handmatige validatie gebruiken voor een regel die afhankelijk is van bestaande gegevens.

**Moeilijkheid: gemiddeld.**

## Opdracht

Een uitleendienst registreert uitleningen van materiaal. Maak een ASP.NET Core Web API met `Materiaal` (`Id` als `int`, `Naam` als `string`) en `Uitlening` (`Id` als `int`, `MateriaalId` als `int`, `Uitlener` als `string`, `AantalDagen` als `int`). De applicatie start met materialen met ID's `1` (`Projector`) en `2` (`Microfoon`), en zonder uitleningen.

Maak `UitleningWriteDto` met `MateriaalId`, `Uitlener` en `AantalDagen`. Maak `UitleningDto` met `Id`, `MateriaalNaam`, `Uitlener` en `AantalDagen`. De API mag geen entiteit rechtstreeks accepteren of retourneren.

Voorzie in `UitleningenController`:

| Methode en route | Gedrag |
| --- | --- |
| `POST /api/uitleningen` | Maakt een uitlening aan en geeft status `201` met `UitleningDto` terug. |
| `GET /api/uitleningen/{id}` | Geeft status `200` met `UitleningDto`, of `404` als de uitlening niet bestaat. |

Gebruik Data Annotations om `Uitlener` verplicht te maken en een lengte van 2 tot en met 60 tekens af te dwingen. `AantalDagen` moet tussen 1 en 30 liggen. Voer daarnaast handmatige validatie uit: `MateriaalId` moet overeenkomen met een bestaand materiaal. Voeg bij een onbekend materiaal een fout toe aan `ModelState` en geef status `400`; er mag dan geen uitlening worden opgeslagen. Bij geldige invoer krijgt de uitlening een unieke positieve ID. De `MateriaalNaam` in de response komt overeen met het gekozen materiaal. Een volgende GET geeft dezelfde gegevens terug.

De opslag en de mapping zijn vrij te kiezen. De validatie en responses moeten voor dezelfde invoer steeds hetzelfde resultaat opleveren.
