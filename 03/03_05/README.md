# 03_05

Een school hanteert de volgende regels voor het toekennen van een studierichting:

- Als de student gemiddeld 75% of meer haalt én wiskunde heeft gevolgd, kan de student kiezen voor de richting "Wetenschap".
- Als de student gemiddeld 75% of meer haalt maar wiskunde niet heeft gevolgd, kan de student kiezen voor de richting "Letteren".
- Als de student gemiddeld tussen 60% en 74% haalt, wordt de student doorverwezen naar de richting "Techniek".
- Als de student minder dan 60% haalt, wordt de student doorverwezen naar de richtingskeuzebegeleiding.

Vraag de gebruiker om zijn gemiddelde percentage en of hij/zij wiskunde heeft gevolgd (ja/nee). Toon de aanbevolen studierichting.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=15, nee


**Input:**

```
15
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 2

**Description:** Run 2: args=68, nee


**Input:**

```
68
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Techniek
```

---

### Case 3

**Description:** Run 3: args=21, ja


**Input:**

```
21
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 4

**Description:** Run 4: args=2, ja


**Input:**

```
2
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 5

**Description:** Run 5: args=12, nee


**Input:**

```
12
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 6

**Description:** Run 6: args=73, ja


**Input:**

```
73
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Techniek
```

---

### Case 7

**Description:** Run 7: args=77, ja


**Input:**

```
77
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Wetenschap
```

---

### Case 8

**Description:** Run 8: args=98, ja


**Input:**

```
98
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Wetenschap
```

---

### Case 9

**Description:** Run 9: args=69, nee


**Input:**

```
69
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Techniek
```

---

### Case 10

**Description:** Run 10: args=5, ja


**Input:**

```
5
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 11

**Description:** Run 11: args=55, ja


**Input:**

```
55
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 12

**Description:** Run 12: args=14, nee


**Input:**

```
14
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 13

**Description:** Run 13: args=6, nee


**Input:**

```
6
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 14

**Description:** Run 14: args=56, nee


**Input:**

```
56
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 15

**Description:** Run 15: args=65, ja


**Input:**

```
65
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Techniek
```

---

### Case 16

**Description:** Run 16: args=22, ja


**Input:**

```
22
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 17

**Description:** Run 17: args=25, ja


**Input:**

```
25
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 18

**Description:** Run 18: args=99, nee


**Input:**

```
99
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Letteren
```

---

### Case 19

**Description:** Run 19: args=98, nee


**Input:**

```
98
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Letteren
```

---

### Case 20

**Description:** Run 20: args=87, nee


**Input:**

```
87
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Letteren
```

---

### Case 21

**Description:** Run 21: args=12, ja


**Input:**

```
12
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 22

**Description:** Run 22: args=47, nee


**Input:**

```
47
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 23

**Description:** Run 23: args=53, nee


**Input:**

```
53
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 24

**Description:** Run 24: args=37, ja


**Input:**

```
37
ja
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): richtingskeuzebegeleiding
```

---

### Case 25

**Description:** Run 25: args=65, nee


**Input:**

```
65
nee
```

**Expected Output:**

```
Geef je gemiddelde percentage: Heb je wiskunde gevolgd? (ja/nee): Techniek
```

---
