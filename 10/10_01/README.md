# 10_01

## Leerdoel

Na deze oefening kan je een write-DTO met Data Annotations gebruiken om invoer voor een POST-endpoint te beperken en valideren. Je voorkomt dat een client interne velden kan instellen.

**Moeilijkheid: gemakkelijk.**

## Opdracht

Een museum wil nieuwe tentoonstellingen via een API registreren. Maak een ASP.NET Core Web API met een `Tentoonstelling` met `Id` (`int`), `Titel` (`string`), `Beschrijving` (`string`), `MaximaalAantalBezoekers` (`int`) en `Gepubliceerd` (`bool`). Nieuwe tentoonstellingen zijn standaard niet gepubliceerd.

Maak `TentoonstellingWriteDto` met uitsluitend `Titel`, `Beschrijving` en `MaximaalAantalBezoekers`, en een `TentoonstellingDto` met alle properties van de entiteit en dezelfde types. Gebruik DTO's als grens van de API: accepteer en retourneer geen `Tentoonstelling` rechtstreeks.

Voorzie in `TentoonstellingenController`:

| Methode en route | Gedrag |
| --- | --- |
| `POST /api/tentoonstellingen` | Maakt bij geldige invoer een tentoonstelling aan en geeft status `201` met de nieuwe `TentoonstellingDto` terug. |
| `GET /api/tentoonstellingen/{id}` | Geeft status `200` met de `TentoonstellingDto` als het ID bestaat, anders status `404`. |

Valideer met Data Annotations dat `Titel` verplicht is en 3 tot en met 80 tekens bevat, `Beschrijving` verplicht is en maximaal 300 tekens bevat, en `MaximaalAantalBezoekers` tussen 1 en 5000 ligt. Ongeldige invoer geeft status `400` en verandert de gegevensbron niet. Bij geldige invoer krijgt de tentoonstelling een unieke positieve ID en is `Gepubliceerd` `false`, ook als de client een extra JSON-veld `gepubliceerd: true` meestuurt. De gegevensbron moet de aangemaakte tentoonstelling bewaren zolang de applicatie draait.

De interne opslag en de manier waarop je de ID genereert zijn vrij te kiezen.
