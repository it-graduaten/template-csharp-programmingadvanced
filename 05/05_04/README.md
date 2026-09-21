# 05_04

Maak een programma dat de gebruiker vraagt hoeveel namen hij of zij wil invoeren. Vervolgens vraagt het programma die namen één voor één en slaat ze op in een array. Daarna vraagt het programma naar een letter, en telt het hoeveel namen beginnen met die letter (ongeacht hoofd- of kleine letters). Het programma toont het aantal namen dat met die letter begint.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=4, Ines, Piet, Kurt, Ronny, I


**Input:**

```
4
Ines
Piet
Kurt
Ronny
I
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef een letter: Aantal namen dat begint met 'I': 1
```

---

### Case 2

**Description:** Run 2: args=4, Sandra, Kevin, Roger, Peggy, B


**Input:**

```
4
Sandra
Kevin
Roger
Peggy
B
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef een letter: Aantal namen dat begint met 'B': 0
```

---

### Case 3

**Description:** Run 3: args=3, Muhammed, Ludovicus, Karin, Q


**Input:**

```
3
Muhammed
Ludovicus
Karin
Q
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef een letter: Aantal namen dat begint met 'Q': 0
```

---

### Case 4

**Description:** Run 4: args=1, Elisabeth, M


**Input:**

```
1
Elisabeth
M
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef een letter: Aantal namen dat begint met 'M': 0
```

---

### Case 5

**Description:** Run 5: args=1, Laura, U


**Input:**

```
1
Laura
U
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef een letter: Aantal namen dat begint met 'U': 0
```

---

### Case 6

**Description:** Run 6: args=5, Lucien, Gabrielle, Bernadette, Frieda, Marc, D


**Input:**

```
5
Lucien
Gabrielle
Bernadette
Frieda
Marc
D
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef naam 5: Geef een letter: Aantal namen dat begint met 'D': 0
```

---

### Case 7

**Description:** Run 7: args=1, Mohamed, X


**Input:**

```
1
Mohamed
X
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef een letter: Aantal namen dat begint met 'X': 0
```

---

### Case 8

**Description:** Run 8: args=4, Anita, Eva, Theo, René, A


**Input:**

```
4
Anita
Eva
Theo
René
A
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef een letter: Aantal namen dat begint met 'A': 1
```

---

### Case 9

**Description:** Run 9: args=4, Amelie, Marc, Vic, Fatima, A


**Input:**

```
4
Amelie
Marc
Vic
Fatima
A
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef een letter: Aantal namen dat begint met 'A': 1
```

---

### Case 10

**Description:** Run 10: args=5, Nils, Yvonne, Ryan, Peter, André, U


**Input:**

```
5
Nils
Yvonne
Ryan
Peter
André
U
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef naam 5: Geef een letter: Aantal namen dat begint met 'U': 0
```

---
