# 06_04

Maak een programma dat de gebruiker vraagt hoeveel namen hij of zij wil invoeren. Vervolgens vraagt het programma die namen één voor één. Tot slot toont het programma alle namen terug, samen met hun index in de lijst (beginnend bij 0).

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=3, Jayden, Inge, Sander


**Input:**

```
3
Jayden
Inge
Sander
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Index 0: Jayden
Index 1: Inge
Index 2: Sander
```

---

### Case 2

**Description:** Run 2: args=2, Robin, Sarah


**Input:**

```
2
Robin
Sarah
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Index 0: Robin
Index 1: Sarah
```

---

### Case 3

**Description:** Run 3: args=5, Christel, Bart, Ellie, Karen, Lutgarde


**Input:**

```
5
Christel
Bart
Ellie
Karen
Lutgarde
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef naam 5: Index 0: Christel
Index 1: Bart
Index 2: Ellie
Index 3: Karen
Index 4: Lutgarde
```

---

### Case 4

**Description:** Run 4: args=5, Johan, Mathijs, Joeri, Lara, Nore


**Input:**

```
5
Johan
Mathijs
Joeri
Lara
Nore
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef naam 5: Index 0: Johan
Index 1: Mathijs
Index 2: Joeri
Index 3: Lara
Index 4: Nore
```

---

### Case 5

**Description:** Run 5: args=2, Jeannette, Cecile


**Input:**

```
2
Jeannette
Cecile
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Index 0: Jeannette
Index 1: Cecile
```

---

### Case 6

**Description:** Run 6: args=1, Maria


**Input:**

```
1
Maria
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Index 0: Maria
```

---

### Case 7

**Description:** Run 7: args=4, Brenda, Marc, Kevin, Daniel


**Input:**

```
4
Brenda
Marc
Kevin
Daniel
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Index 0: Brenda
Index 1: Marc
Index 2: Kevin
Index 3: Daniel
```

---

### Case 8

**Description:** Run 8: args=3, Hanne, Bart, Wim


**Input:**

```
3
Hanne
Bart
Wim
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Index 0: Hanne
Index 1: Bart
Index 2: Wim
```

---

### Case 9

**Description:** Run 9: args=1, Imane


**Input:**

```
1
Imane
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Index 0: Imane
```

---

### Case 10

**Description:** Run 10: args=5, Juliette, Ann, Danielle, Eline, Noëlla


**Input:**

```
5
Juliette
Ann
Danielle
Eline
Noëlla
```

**Expected Output:**

```
Hoeveel namen wil je invoeren?
Geef naam 1: Geef naam 2: Geef naam 3: Geef naam 4: Geef naam 5: Index 0: Juliette
Index 1: Ann
Index 2: Danielle
Index 3: Eline
Index 4: Noëlla
```

---
