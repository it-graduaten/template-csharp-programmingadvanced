# 01_03

## Leerdoel

Na deze oefening kan je meerdere GET-endpoints logisch groeperen binnen één ASP.NET Core API-controller.

Je leert verschillende routeparameters combineren, waarden uit een URL gebruiken in gewone C#-logica en op basis van die waarden een dynamisch antwoord genereren.

Daarnaast oefen je hoe de combinatie van de basisroute van een controller en de route van een specifieke methode samen de uiteindelijke URL van een endpoint vormt.

##

## Opdracht

De fictieve pizzeria **Pizza Palazzo** wil klanten helpen bij het kiezen van hun pizza.

Daarom willen ze een eenvoudige Bestelhulp API waarmee klanten informatie kunnen opvragen over de pizzeria, pizzaformaten en pizzakeuzes.

Jouw taak is om een `PizzeriaController` te maken met verschillende GET-endpoints.

Via de API moeten klanten:

1. de specialiteit van het huis kunnen opvragen;
2. informatie over een pizzaformaat kunnen opvragen;
3. een persoonlijk bericht kunnen krijgen bij hun pizzakeuze;
4. een eenvoudige prijsindicatie kunnen opvragen op basis van een pizzaformaat.

Implementeer onderstaande functionaliteiten.

### 1. Specialiteit van het huis

Voorzie een GET-endpoint op:

`/pizzeria`

Dit endpoint geeft volgende tekst terug:

`De specialiteit van Pizza Palazzo is de Pizza Palazzo Special.`

### 2. Informatie over een pizzaformaat

Voorzie een GET-endpoint op:

`/pizzeria/formaat/{formaat}`

Het endpoint ontvangt het gewenste pizzaformaat via de route.

De API moet drie formaten herkennen:

* small
* medium
* large

Geef voor ieder formaat het bijbehorende bericht terug:

| Formaat | Bericht                                        |
| ------- | ---------------------------------------------- |
| small   | Een small pizza heeft een diameter van 20 cm.  |
| medium  | Een medium pizza heeft een diameter van 30 cm. |
| large   | Een large pizza heeft een diameter van 40 cm.  |

Wordt een onbekend formaat opgegeven, geef dan het bericht terug:

`Dit pizzaformaat bestaat niet.`

Je mag ervan uitgaan dat de waarden voor `{formaat}` in kleine letters worden ingegeven.

### 3. Persoonlijke pizzakeuze

Voorzie een GET-endpoint op:

`/pizzeria/keuze/{naam}/{pizza}`

Dit endpoint ontvangt twee waarden via de URL:

* `{naam}`: de naam van de klant;
* `{pizza}`: de gekozen pizza.

Gebruik beide routeparameters om een persoonlijk bericht samen te stellen.

Bijvoorbeeld:

`GET /pizzeria/keuze/Emma/Margherita`

geeft als resultaat:

`Emma kiest voor een pizza Margherita. Smakelijk!`

Een ander request:

`GET /pizzeria/keuze/Youssef/Diavola`

geeft als resultaat:

`Youssef kiest voor een pizza Diavola. Smakelijk!`

De naam en pizzakeuze moeten afkomstig zijn uit de routeparameters. Je mag dus geen specifieke namen of pizzakeuzes hardcoderen.

### 4. Prijsindicatie op basis van formaat

Voorzie een GET-endpoint op:

`/pizzeria/prijs/{formaat}`

De API moet op basis van het opgegeven formaat de basisprijs van een pizza teruggeven.

Gebruik volgende prijzen:

| Formaat | Prijs |
| ------- | ----: |
| small   |    €8 |
| medium  |   €11 |
| large   |   €14 |

Geef het resultaat terug in volgende vorm:

`Een {formaat} pizza kost €{prijs}.`

Bijvoorbeeld:

`GET /pizzeria/prijs/medium`

geeft als resultaat:

`Een medium pizza kost €11.`

`GET /pizzeria/prijs/large`

geeft als resultaat:

`Een large pizza kost €14.`

Wordt een onbekend formaat opgegeven, geef dan het bericht terug:

`Voor dit pizzaformaat is geen prijs beschikbaar.`
