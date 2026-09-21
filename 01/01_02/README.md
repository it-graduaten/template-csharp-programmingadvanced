# 01_02

## Leerdoel

Na deze oefening kan je een eenvoudige ASP.NET Core API-controller maken met meerdere GET-endpoints.

Je leert verschillende routes binnen één controller definiëren, waarden uit de URL ontvangen via routeparameters en deze waarden gebruiken in gewone C#-logica.

Daarnaast leer je hoe je meerdere GET-endpoints logisch van elkaar onderscheidt en hoe ASP.NET Core op basis van de combinatie van route en HTTP-verb bepaalt welke methode uitgevoerd moet worden.

##

## Opdracht

Het fictieve muziekfestival SoundWave Festival wil bezoekers via een eenvoudige API informeren.

Jouw taak is om een FestivalController te maken met verschillende GET-endpoints.

Via de API moeten bezoekers:

1. een algemeen welkomstbericht kunnen opvragen;
2. een persoonlijk welkomstbericht kunnen krijgen;
3. informatie over een festivalpodium kunnen opvragen;
4. kunnen zien hoeveel dagen het nog duurt tot het festival begint.

Implementeer onderstaande functionaliteiten.

### 1. Algemeen welkomstbericht

Voorzie een GET-endpoint op:

`/festival`

Dit endpoint geeft volgende tekst terug:

`Welkom op SoundWave Festival!`

### 2. Persoonlijk welkomstbericht

Voorzie een GET-endpoint op:

`/festival/welkom/{naam}`

De naam van de bezoeker wordt meegegeven via de URL.

Bijvoorbeeld:

`GET /festival/welkom/Emma`

geeft als resultaat:

`Welkom op SoundWave Festival, Emma!`

De naam moet afkomstig zijn uit de routeparameter. Je mag dus geen specifieke bezoekersnamen hardcoderen.

### 3. Informatie over een festivalpodium

Voorzie een GET-endpoint op:

`/festival/podium/{podium}`

Het endpoint ontvangt de naam van een podium via de route.

De API moet drie podia herkennen:

* main
* rock
* dance

Geef voor ieder podium het bijbehorende bericht terug:

| Podium | Bericht                                                          |
| ------ | ---------------------------------------------------------------- |
| main   | Op het Main Stage spelen de grootste artiesten van het festival. |
| rock   | Op het Rock Stage hoor je gitaren, drums en stevige muziek.      |
| dance  | Op het Dance Stage spelen DJ's en elektronische artiesten.       |

Wordt een onbekend podium opgegeven, geef dan het bericht terug:

`Dit podium bestaat niet.`

### 4. Aftellen naar het festival

Voorzie een GET-endpoint op:

`/festival/aftellen/{dagen}`

De routeparameter `{dagen}` stelt het aantal dagen voor tot SoundWave Festival begint.

Geef volgend bericht terug:

`Nog {dagen} dagen tot SoundWave Festival!`

Bijvoorbeeld:

`GET /festival/aftellen/12` geeft als resultaat: `Nog 12 dagen tot SoundWave Festival!`

`GET /festival/aftellen/5` geeft als resultaat: `Nog 5 dagen tot SoundWave Festival!`

`GET /festival/aftellen/1` geeft als resultaat: `Nog 1 dagen tot SoundWave Festival!`
