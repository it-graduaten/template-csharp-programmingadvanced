# 06_09

Maak een programma dat de gebruiker vraagt hoeveel scores hij of zij wil invoeren. Vervolgens vraagt het programma die scores één voor één, waarbij elke score tussen 0 en 20 moet liggen. Tot slot toont het programma het totaal aantal scores, het totaal van alle scores, en het gemiddelde van alle scores.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=1, 25, 5


**Input:**

```
1
25
5
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Ongeldige score. Geef een score tussen 0 en 20: Aantal scores: 1
Totaal: 5
Gemiddelde: 5
```

---

### Case 2

**Description:** Run 2: args=2, 25, 8, 15


**Input:**

```
2
25
8
15
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Ongeldige score. Geef een score tussen 0 en 20: Geef score 2: Aantal scores: 2
Totaal: 23
Gemiddelde: 11.5
```

---

### Case 3

**Description:** Run 3: args=3, -1, 10, -1, 10, 25, 18


**Input:**

```
3
-1
10
-1
10
25
18
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Ongeldige score. Geef een score tussen 0 en 20: Geef score 2: Ongeldige score. Geef een score tussen 0 en 20: Geef score 3: Ongeldige score. Geef een score tussen 0 en 20: Aantal scores: 3
Totaal: 38
Gemiddelde: 12.666666666666666
```

---

### Case 4

**Description:** Run 4: args=5, -1, 19, 25, 3, 25, 11, -1, 7, 25, 3


**Input:**

```
5
-1
19
25
3
25
11
-1
7
25
3
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Ongeldige score. Geef een score tussen 0 en 20: Geef score 2: Ongeldige score. Geef een score tussen 0 en 20: Geef score 3: Ongeldige score. Geef een score tussen 0 en 20: Geef score 4: Ongeldige score. Geef een score tussen 0 en 20: Geef score 5: Ongeldige score. Geef een score tussen 0 en 20: Aantal scores: 5
Totaal: 43
Gemiddelde: 8.6
```

---

### Case 5

**Description:** Run 5: args=1, -1, 17


**Input:**

```
1
-1
17
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Ongeldige score. Geef een score tussen 0 en 20: Aantal scores: 1
Totaal: 17
Gemiddelde: 17
```

---

### Case 6

**Description:** Run 6: args=4, 15, 15, -1, 20, 15


**Input:**

```
4
15
15
-1
20
15
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Ongeldige score. Geef een score tussen 0 en 20: Geef score 4: Aantal scores: 4
Totaal: 65
Gemiddelde: 16.25
```

---

### Case 7

**Description:** Run 7: args=5, 25, 13, 15, -1, 3, -1, 20, -1, 14


**Input:**

```
5
25
13
15
-1
3
-1
20
-1
14
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Ongeldige score. Geef een score tussen 0 en 20: Geef score 2: Geef score 3: Ongeldige score. Geef een score tussen 0 en 20: Geef score 4: Ongeldige score. Geef een score tussen 0 en 20: Geef score 5: Ongeldige score. Geef een score tussen 0 en 20: Aantal scores: 5
Totaal: 65
Gemiddelde: 13
```

---

### Case 8

**Description:** Run 8: args=4, 15, 15, 15, 25, 7


**Input:**

```
4
15
15
15
25
7
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Geef score 4: Ongeldige score. Geef een score tussen 0 en 20: Aantal scores: 4
Totaal: 52
Gemiddelde: 13
```

---

### Case 9

**Description:** Run 9: args=4, 25, 9, 15, 15, 15


**Input:**

```
4
25
9
15
15
15
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Ongeldige score. Geef een score tussen 0 en 20: Geef score 2: Geef score 3: Geef score 4: Aantal scores: 4
Totaal: 54
Gemiddelde: 13.5
```

---

### Case 10

**Description:** Run 10: args=3, -1, 11, 25, 1, 25, 20


**Input:**

```
3
-1
11
25
1
25
20
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Ongeldige score. Geef een score tussen 0 en 20: Geef score 2: Ongeldige score. Geef een score tussen 0 en 20: Geef score 3: Ongeldige score. Geef een score tussen 0 en 20: Aantal scores: 3
Totaal: 32
Gemiddelde: 10.666666666666666
```

---
