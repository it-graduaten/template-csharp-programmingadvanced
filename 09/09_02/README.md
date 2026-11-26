# 09_02

## Leerdoel

Na deze oefening kan je een write-DTO inzetten om vast te leggen welke invoer een endpoint accepteert, en die invoer omzetten naar een entiteit zonder door de client bepaalde velden over te nemen.

**Moeilijkheid: gemiddeld.**

## Opdracht

Een buurthuis wil activiteiten registreren. Maak een ASP.NET Core Web API met een entiteit `Activiteit` met properties `Id` (`int`), `Naam` (`string`), `Beschrijving` (`string`), `MaximumDeelnemers` (`int`) en `Goedgekeurd` (`bool`). Nieuwe activiteiten zijn standaard niet goedgekeurd.

Maak een write-DTO `ActiviteitCreateDto` met uitsluitend `Naam` (`string`), `Beschrijving` (`string`) en `MaximumDeelnemers` (`int`). De client mag geen `Id` of `Goedgekeurd` instellen. Maak daarnaast een read-DTO `ActiviteitDto` met `Id`, `Naam`, `Beschrijving`, `MaximumDeelnemers` en `Goedgekeurd` met dezelfde types als in de entiteit.

Voorzie in `ActiviteitenController`:

| Methode en route | Gedrag |
| --- | --- |
| `POST /api/activiteiten` | Accepteert een JSON-body die overeenkomt met `ActiviteitCreateDto`. Bij geldige invoer wordt één activiteit aangemaakt, met een unieke positieve `Id` en `Goedgekeurd` gelijk aan `false`. Geeft status `201` en de aangemaakte activiteit als `ActiviteitDto` terug. |
| `GET /api/activiteiten/{id}` | Geeft status `200` met de activiteit als `ActiviteitDto`, of `404` als het ID niet bestaat. |

`Naam` en `Beschrijving` mogen na trimmen niet leeg zijn en `MaximumDeelnemers` moet groter zijn dan nul. Ongeldige invoer geeft status `400` en mag de gegevensbron niet wijzigen. De gegevensbron moet tijdens de levensduur van de applicatie wijzigingen bewaren, zodat een aangemaakte activiteit direct via de GET-route opvraagbaar is. De gegenereerde ID mag niet door de client worden gekozen. Gebruik DTO’s aan de API-grens; geef of accepteer de entiteit niet rechtstreeks.

De interne opslag en de manier waarop je ID’s genereert zijn vrij te kiezen, zolang het gedrag aan deze eisen voldoet.
