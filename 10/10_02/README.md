# 10_02

## Leerdoel

Na deze oefening kan je een write-DTO voor een PUT-endpoint gebruiken en eenvoudige validatie combineren met het bijwerken van een bestaand record zonder interne velden door de client te laten bepalen.

**Moeilijkheid: gemiddeld.**

## Opdracht

Een sportclub beheert trainingsgroepen via een API. Maak een ASP.NET Core Web API met een `Trainingsgroep` met properties `Id` (`int`), `Naam` (`string`), `Dag` (`string`), `MaximumLeden` (`int`) en `Actief` (`bool`). De applicatie start met één trainingsgroep: ID `1`, naam `Junioren`, dag `maandag`, maximaal 20 leden en actief.

Maak `TrainingsgroepWriteDto` met uitsluitend `Naam`, `Dag` en `MaximumLeden`, en `TrainingsgroepDto` met alle entiteitsproperties. De API accepteert en retourneert alleen DTO's, geen entiteiten. Gebruik Data Annotations om `Naam` verplicht te maken (2–60 tekens), `Dag` verplicht te maken (2–15 tekens) en `MaximumLeden` te beperken tot 1–80.

Voorzie in `TrainingsgroepenController`:

| Methode en route | Gedrag |
| --- | --- |
| `GET /api/trainingsgroepen/{id}` | Geeft status `200` en de groep als `TrainingsgroepDto`, of status `404` als deze niet bestaat. |
| `PUT /api/trainingsgroepen/{id}` | Bij bestaand ID en geldige body worden `Naam`, `Dag` en `MaximumLeden` bijgewerkt; antwoordstatus `204`. |

Een PUT voor een onbekend ID geeft `404`. Een ongeldige body geeft `400`; in beide gevallen blijft de bestaande groep ongewijzigd. Het ID in de URL bepaalt welke groep wordt bijgewerkt. Een eventueel meegestuurd `id` of `actief` in de JSON-body mag het bestaande ID en de waarde van `Actief` niet veranderen. Na een succesvolle PUT moet een volgende GET de nieuwe waarden tonen. De gegevensbron moet tijdens de levensduur van de applicatie wijzigingen bewaren.

De interne opslag en mapping zijn vrij te kiezen.
