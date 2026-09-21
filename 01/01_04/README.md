# 01_04

## Leerdoel

Na deze oefening kan je een ASP.NET Core API-controller maken met meerdere GET-endpoints die verschillende soorten routeparameters verwerken.

Je leert meerdere waarden uit een URL ontvangen, verschillende datatypes gebruiken als routeparameter en deze waarden combineren met gewone C#-logica.

Daarnaast oefen je zelfstandig met routing: je bepaalt welke informatie via de URL wordt doorgegeven en hoe de combinatie van de controllerroute en methoderoute het uiteindelijke endpoint vormt.

##

## Opdracht

Het fictieve ruimtevaartagentschap **Nova Space Agency** bereidt de ruimtemissie **Odyssey** voor.

Het controlecentrum wil een eenvoudige API waarmee informatie over de missie kan worden opgevraagd. De API wordt gebruikt om astronauten te verwelkomen, informatie over bestemmingen op te vragen en de voortgang van de missie te controleren.

Jouw taak is om een `MissionController` te maken met verschillende GET-endpoints.

Via de API moeten gebruikers:

1. algemene informatie over de missie kunnen opvragen;
2. een astronaut persoonlijk kunnen verwelkomen;
3. informatie over een bestemming kunnen opvragen;
4. de voortgang naar een bestemming kunnen controleren.

Implementeer onderstaande functionaliteiten.

### 1. Algemene missie-informatie

Voorzie een GET-endpoint op:

`/mission`

Dit endpoint geeft volgende tekst terug:

`Odyssey is klaar voor vertrek!`

### 2. Astronaut verwelkomen

Voorzie een GET-endpoint op:

`/mission/astronaut/{naam}`

De naam van de astronaut wordt meegegeven via de URL.

Bijvoorbeeld:

`GET /mission/astronaut/Emma`

geeft als resultaat:

`Astronaut Emma, welkom aan boord van Odyssey!`

Een andere astronaut moet uiteraard een persoonlijk bericht krijgen.

Bijvoorbeeld:

`GET /mission/astronaut/Youssef`

geeft als resultaat:

`Astronaut Youssef, welkom aan boord van Odyssey!`

De naam moet afkomstig zijn uit de routeparameter. Je mag dus geen specifieke namen hardcoderen.

### 3. Informatie over een bestemming

Voorzie een GET-endpoint op:

`/mission/bestemming/{bestemming}`

Het endpoint ontvangt de naam van een bestemming via de route.

De API moet drie bestemmingen herkennen:

* maan
* mars
* europa

Geef voor iedere bestemming het bijbehorende bericht terug:

| Bestemming | Bericht                                                         |
| ---------- | --------------------------------------------------------------- |
| maan       | De Maan is de natuurlijke satelliet van de aarde.               |
| mars       | Mars staat bekend als de rode planeet.                          |
| europa     | Europa is een maan van Jupiter en heeft een bevroren oppervlak. |

Wordt een onbekende bestemming opgegeven, geef dan het bericht terug:

`Deze bestemming is niet opgenomen in de Odyssey-missie.`

Je mag ervan uitgaan dat de waarden voor `{bestemming}` in kleine letters worden ingegeven.

### 4. Voortgang van de ruimtereis

Het controlecentrum wil kunnen bepalen in welke fase een ruimtereis zich bevindt.

Voorzie hiervoor een GET-endpoint met twee routeparameters:

`/mission/reis/{bestemming}/{afstand}`

De routeparameters stellen het volgende voor:

* `{bestemming}`: de naam van de bestemming;
* `{afstand}`: het aantal kilometer dat nog moet worden afgelegd.

`afstand` wordt in de C#-methode ontvangen als een `int`.

Gebruik de resterende afstand om een statusbericht te bepalen.

* Minder dan 1.000 kilometer: de bestemming is bijna bereikt.
* 1.000 tot en met 100.000 kilometer: het ruimteschip is onderweg naar de bestemming.
* Meer dan 100.000 kilometer: het ruimteschip heeft nog een lange reis voor de boeg.

De naam van de bestemming moet telkens in het antwoord verwerkt worden.

Bijvoorbeeld:

`GET /mission/reis/maan/500`

geeft als resultaat:

`Odyssey heeft maan bijna bereikt!`

`GET /mission/reis/maan/50000`

geeft als resultaat:

`Odyssey is onderweg naar maan.`

`GET /mission/reis/mars/250000`

geeft als resultaat:

`Odyssey heeft nog een lange reis naar mars voor de boeg.`

Zowel de bestemming als de afstand moeten afkomstig zijn uit de routeparameters. Je mag deze waarden dus niet hardcoderen.
