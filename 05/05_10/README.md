# 05_10

Maak een programma dat de gebruiker vraagt hoeveel scores hij of zij wil invoeren. Vervolgens vraagt het programma die scores één voor één en slaat ze op in een array. Daarna bepaalt het programma hoeveel scores minstens 10 zijn (geslaagd) en hoeveel scores minder dan 10 zijn (gezakt), en toont deze aantallen.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=2, 8, -1


**Input:**

```
2
8
-1
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geslaagd: 0
Gezakt: 2
```

---

### Case 2

**Description:** Run 2: args=5, 3, -5, 10, 19, 11


**Input:**

```
5
3
-5
10
19
11
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Geef score 4: Geef score 5: Geslaagd: 3
Gezakt: 2
```

---

### Case 3

**Description:** Run 3: args=2, -6, 10


**Input:**

```
2
-6
10
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geslaagd: 1
Gezakt: 1
```

---

### Case 4

**Description:** Run 4: args=4, -1, 10, 12, -3


**Input:**

```
4
-1
10
12
-3
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Geef score 4: Geslaagd: 2
Gezakt: 2
```

---

### Case 5

**Description:** Run 5: args=2, 3, -3


**Input:**

```
2
3
-3
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geslaagd: 0
Gezakt: 2
```

---

### Case 6

**Description:** Run 6: args=4, -10, -4, 4, 16


**Input:**

```
4
-10
-4
4
16
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Geef score 4: Geslaagd: 1
Gezakt: 3
```

---

### Case 7

**Description:** Run 7: args=4, 11, -9, 13, 16


**Input:**

```
4
11
-9
13
16
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Geef score 4: Geslaagd: 3
Gezakt: 1
```

---

### Case 8

**Description:** Run 8: args=5, 14, -7, -1, 1, -8


**Input:**

```
5
14
-7
-1
1
-8
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Geef score 4: Geef score 5: Geslaagd: 1
Gezakt: 4
```

---

### Case 9

**Description:** Run 9: args=3, -9, 9, -4


**Input:**

```
3
-9
9
-4
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Geslaagd: 0
Gezakt: 3
```

---

### Case 10

**Description:** Run 10: args=3, 15, -4, -8


**Input:**

```
3
15
-4
-8
```

**Expected Output:**

```
Hoeveel scores wil je invoeren?
Geef score 1: Geef score 2: Geef score 3: Geslaagd: 1
Gezakt: 2
```

---
