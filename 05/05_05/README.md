# 05_05

Maak een programma dat de gebruiker vraagt hoeveel getallen hij of zij wil invoeren. Vervolgens vraagt het programma die getallen één voor één en slaat ze op in een array. Daarna vraagt het programma naar een getal om te zoeken. Het programma doorzoekt de array naar dat getal en toont of het gevonden is, en zo ja, op welke index(en) het zich bevindt.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=2, 16, -3, 19


**Input:**

```
2
16
-3
19
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef een getal om te zoeken: Het getal 19 is niet gevonden.
```

---

### Case 2

**Description:** Run 2: args=4, 3, 2, 7, -8, -5


**Input:**

```
4
3
2
7
-8
-5
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef getal 3: Geef getal 4: Geef een getal om te zoeken: Het getal -5 is niet gevonden.
```

---

### Case 3

**Description:** Run 3: args=5, 13, 14, -1, 18, 9, -9


**Input:**

```
5
13
14
-1
18
9
-9
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef getal 3: Geef getal 4: Geef getal 5: Geef een getal om te zoeken: Het getal -9 is niet gevonden.
```

---

### Case 4

**Description:** Run 4: args=4, -4, -4, 19, -3, 9


**Input:**

```
4
-4
-4
19
-3
9
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef getal 3: Geef getal 4: Geef een getal om te zoeken: Het getal 9 is niet gevonden.
```

---

### Case 5

**Description:** Run 5: args=2, -1, 16, 6


**Input:**

```
2
-1
16
6
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef een getal om te zoeken: Het getal 6 is niet gevonden.
```

---

### Case 6

**Description:** Run 6: args=4, 0, -1, 2, 18, -1


**Input:**

```
4
0
-1
2
18
-1
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef getal 3: Geef getal 4: Geef een getal om te zoeken: Het getal -1 is gevonden op de volgende index(en):
1
```

---

### Case 7

**Description:** Run 7: args=3, 2, 17, 18, -2


**Input:**

```
3
2
17
18
-2
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef getal 3: Geef een getal om te zoeken: Het getal -2 is niet gevonden.
```

---

### Case 8

**Description:** Run 8: args=5, 2, 6, -4, 7, 17, 16


**Input:**

```
5
2
6
-4
7
17
16
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef getal 3: Geef getal 4: Geef getal 5: Geef een getal om te zoeken: Het getal 16 is niet gevonden.
```

---

### Case 9

**Description:** Run 9: args=3, -5, -9, 14, -4


**Input:**

```
3
-5
-9
14
-4
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef getal 3: Geef een getal om te zoeken: Het getal -4 is niet gevonden.
```

---

### Case 10

**Description:** Run 10: args=5, 1, 11, 1, 16, 14, -7


**Input:**

```
5
1
11
1
16
14
-7
```

**Expected Output:**

```
Hoeveel getallen wil je invoeren?
Geef getal 1: Geef getal 2: Geef getal 3: Geef getal 4: Geef getal 5: Geef een getal om te zoeken: Het getal -7 is niet gevonden.
```

---
