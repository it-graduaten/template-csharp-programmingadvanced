# 02_04

Vraag de gebruiker om zijn geslacht (man of vrouw) en zijn leeftijd in jaren. Als de persoon ouder is dan 60 jaar, toon dan "Pensioen". Als de persoon tussen 18 en 60 jaar oud is, toon dan "Werkend". Toon anders "Kind".

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=man, 73


**Input:**

```
man
73
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 2

**Description:** Run 2: args=vrouw, 68


**Input:**

```
vrouw
68
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 3

**Description:** Run 3: args=vrouw, 2


**Input:**

```
vrouw
2
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 4

**Description:** Run 4: args=man, 14


**Input:**

```
man
14
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 5

**Description:** Run 5: args=vrouw, 18


**Input:**

```
vrouw
18
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Werkend
```

---

### Case 6

**Description:** Run 6: args=man, 17


**Input:**

```
man
17
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 7

**Description:** Run 7: args=man, 0


**Input:**

```
man
0
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 8

**Description:** Run 8: args=vrouw, 23


**Input:**

```
vrouw
23
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Werkend
```

---

### Case 9

**Description:** Run 9: args=vrouw, 36


**Input:**

```
vrouw
36
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Werkend
```

---

### Case 10

**Description:** Run 10: args=man, 75


**Input:**

```
man
75
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 11

**Description:** Run 11: args=man, 72


**Input:**

```
man
72
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 12

**Description:** Run 12: args=vrouw, 86


**Input:**

```
vrouw
86
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 13

**Description:** Run 13: args=vrouw, 37


**Input:**

```
vrouw
37
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Werkend
```

---

### Case 14

**Description:** Run 14: args=vrouw, 71


**Input:**

```
vrouw
71
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 15

**Description:** Run 15: args=vrouw, 32


**Input:**

```
vrouw
32
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Werkend
```

---

### Case 16

**Description:** Run 16: args=vrouw, 14


**Input:**

```
vrouw
14
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 17

**Description:** Run 17: args=vrouw, 1


**Input:**

```
vrouw
1
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 18

**Description:** Run 18: args=vrouw, 98


**Input:**

```
vrouw
98
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 19

**Description:** Run 19: args=vrouw, 34


**Input:**

```
vrouw
34
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Werkend
```

---

### Case 20

**Description:** Run 20: args=vrouw, 89


**Input:**

```
vrouw
89
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 21

**Description:** Run 21: args=vrouw, 15


**Input:**

```
vrouw
15
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 22

**Description:** Run 22: args=man, 13


**Input:**

```
man
13
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 23

**Description:** Run 23: args=vrouw, 1


**Input:**

```
vrouw
1
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Kind
```

---

### Case 24

**Description:** Run 24: args=vrouw, 68


**Input:**

```
vrouw
68
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Pensioen
```

---

### Case 25

**Description:** Run 25: args=vrouw, 53


**Input:**

```
vrouw
53
```

**Expected Output:**

```
Voor welk geslacht vraag je het tarief? Voor welke leeftijd vraag je het tarief? Werkend
```

---
