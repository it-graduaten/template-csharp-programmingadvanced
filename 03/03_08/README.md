# 03_08

Een pretpark hanteert de volgende toegangspolitiek:

- Personen jonger dan 10 jaar mogen het park niet binnen zonder begeleiding van een volwassene.
- Personen tussen 10 en 17 jaar mogen het park alleen binnen als ze vergezeld zijn van een volwassene.
- Personen 18 jaar en ouder mogen altijd het park betreden.

Vraag de gebruiker om zijn leeftijd en geslacht (M of V). Als de persoon tussen 10 en 17 jaar oud is, vraag dan ook of hij/zij vergezeld is van een volwassene (ja/nee). Toon "Toegang toegestaan" of "Toegang geweigerd".

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=1, V, ja


**Input:**

```
1
V
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang geweigerd
```

---

### Case 2

**Description:** Run 2: args=38, M, nee


**Input:**

```
38
M
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 3

**Description:** Run 3: args=28, M, nee


**Input:**

```
28
M
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 4

**Description:** Run 4: args=29, V, nee


**Input:**

```
29
V
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 5

**Description:** Run 5: args=3, V, nee


**Input:**

```
3
V
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang geweigerd
```

---

### Case 6

**Description:** Run 6: args=10, V, nee


**Input:**

```
10
V
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Ben je vergezeld van een volwassene? (ja/neen): Toegang geweigerd
```

---

### Case 7

**Description:** Run 7: args=0, M, nee


**Input:**

```
0
M
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang geweigerd
```

---

### Case 8

**Description:** Run 8: args=36, V, ja


**Input:**

```
36
V
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 9

**Description:** Run 9: args=17, V, ja


**Input:**

```
17
V
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Ben je vergezeld van een volwassene? (ja/neen): Toegang toegestaan
```

---

### Case 10

**Description:** Run 10: args=25, M, ja


**Input:**

```
25
M
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 11

**Description:** Run 11: args=35, M, nee


**Input:**

```
35
M
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 12

**Description:** Run 12: args=24, V, ja


**Input:**

```
24
V
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 13

**Description:** Run 13: args=39, M, ja


**Input:**

```
39
M
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 14

**Description:** Run 14: args=10, V, nee


**Input:**

```
10
V
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Ben je vergezeld van een volwassene? (ja/neen): Toegang geweigerd
```

---

### Case 15

**Description:** Run 15: args=38, M, ja


**Input:**

```
38
M
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 16

**Description:** Run 16: args=34, M, ja


**Input:**

```
34
M
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 17

**Description:** Run 17: args=2, M, nee


**Input:**

```
2
M
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang geweigerd
```

---

### Case 18

**Description:** Run 18: args=38, V, nee


**Input:**

```
38
V
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 19

**Description:** Run 19: args=28, M, nee


**Input:**

```
28
M
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 20

**Description:** Run 20: args=26, V, nee


**Input:**

```
26
V
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 21

**Description:** Run 21: args=17, V, ja


**Input:**

```
17
V
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Ben je vergezeld van een volwassene? (ja/neen): Toegang toegestaan
```

---

### Case 22

**Description:** Run 22: args=30, V, nee


**Input:**

```
30
V
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 23

**Description:** Run 23: args=10, M, ja


**Input:**

```
10
M
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Ben je vergezeld van een volwassene? (ja/neen): Toegang toegestaan
```

---

### Case 24

**Description:** Run 24: args=19, V, nee


**Input:**

```
19
V
nee
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang toegestaan
```

---

### Case 25

**Description:** Run 25: args=8, M, ja


**Input:**

```
8
M
ja
```

**Expected Output:**

```
Geef je leeftijd: Geef je geslacht (M of V): Toegang geweigerd
```

---
