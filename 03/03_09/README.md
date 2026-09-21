# 03_09

Een restaurant biedt de volgende kortingen aan:

- Op maandag t/m vrijdag tussen 11:00 en 14:00 uur: 10% korting op het lunchmenu.
- Op zaterdag en zondag tussen 12:00 en 16:00 uur: 15% korting op het weekendmenu.
- Groepen van meer dan 3 personen krijgen altijd extra 5% korting bovenop de bestaande korting.
- Op alle andere momenten geen korting.

Vraag de gebruiker om de dag van de week (als getal: 1=maandag, ..., 7=zondag), het uur van aankomst, het aantal personen en het totaalbedrag. Bereken en toon het eindbedrag na korting.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=5, 3, 2, 392.92393119117014


**Input:**

```
5
3
2
392.92393119117014
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 392.92393119117014
```

---

### Case 2

**Description:** Run 2: args=4, 9, 10, 437.886631698033


**Input:**

```
4
9
10
437.886631698033
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 415.99230011313136
```

---

### Case 3

**Description:** Run 3: args=3, 19, 2, 41.19942698381921


**Input:**

```
3
19
2
41.19942698381921
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 41.19942698381921
```

---

### Case 4

**Description:** Run 4: args=2, 7, 2, 76.09983798268976


**Input:**

```
2
7
2
76.09983798268976
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 76.09983798268976
```

---

### Case 5

**Description:** Run 5: args=5, 15, 3, 110.50282260567907


**Input:**

```
5
15
3
110.50282260567907
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 110.50282260567907
```

---

### Case 6

**Description:** Run 6: args=7, 3, 7, 71.83569791548157


**Input:**

```
7
3
7
71.83569791548157
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 68.24391301970749
```

---

### Case 7

**Description:** Run 7: args=5, 22, 6, 419.86217889500625


**Input:**

```
5
22
6
419.86217889500625
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 398.86906995025595
```

---

### Case 8

**Description:** Run 8: args=3, 0, 9, 390.9411952663685


**Input:**

```
3
0
9
390.9411952663685
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 371.39413550305005
```

---

### Case 9

**Description:** Run 9: args=5, 11, 9, 140.9016352188004


**Input:**

```
5
11
9
140.9016352188004
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 119.76638993598034
```

---

### Case 10

**Description:** Run 10: args=5, 1, 4, 444.3400333690388


**Input:**

```
5
1
4
444.3400333690388
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 422.12303170058686
```

---

### Case 11

**Description:** Run 11: args=7, 8, 9, 284.7245776579283


**Input:**

```
7
8
9
284.7245776579283
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 270.4883487750319
```

---

### Case 12

**Description:** Run 12: args=6, 22, 10, 439.0205276704575


**Input:**

```
6
22
10
439.0205276704575
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 417.0695012869346
```

---

### Case 13

**Description:** Run 13: args=6, 12, 7, 408.23072276699685


**Input:**

```
6
12
7
408.23072276699685
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 326.58457821359747
```

---

### Case 14

**Description:** Run 14: args=2, 6, 4, 50.11531462681534


**Input:**

```
2
6
4
50.11531462681534
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 47.609548895474575
```

---

### Case 15

**Description:** Run 15: args=2, 4, 1, 388.93889645512184


**Input:**

```
2
4
1
388.93889645512184
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 388.93889645512184
```

---

### Case 16

**Description:** Run 16: args=1, 23, 10, 250.62341205347047


**Input:**

```
1
23
10
250.62341205347047
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 238.09224145079696
```

---

### Case 17

**Description:** Run 17: args=1, 7, 10, 81.85416760614159


**Input:**

```
1
7
10
81.85416760614159
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 77.76145922583451
```

---

### Case 18

**Description:** Run 18: args=5, 13, 9, 316.80613043429


**Input:**

```
5
13
9
316.80613043429
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 269.2852108691465
```

---

### Case 19

**Description:** Run 19: args=3, 9, 7, 142.56727800381077


**Input:**

```
3
9
7
142.56727800381077
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 135.43891410362022
```

---

### Case 20

**Description:** Run 20: args=1, 18, 1, 162.97199137387884


**Input:**

```
1
18
1
162.97199137387884
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 162.97199137387884
```

---

### Case 21

**Description:** Run 21: args=4, 19, 8, 63.44790662556198


**Input:**

```
4
19
8
63.44790662556198
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 60.27551129428388
```

---

### Case 22

**Description:** Run 22: args=1, 13, 1, 201.22961355624219


**Input:**

```
1
13
1
201.22961355624219
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 181.10665220061796
```

---

### Case 23

**Description:** Run 23: args=1, 22, 2, 478.3198611280883


**Input:**

```
1
22
2
478.3198611280883
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 478.3198611280883
```

---

### Case 24

**Description:** Run 24: args=1, 7, 7, 10.107107688757514


**Input:**

```
1
7
7
10.107107688757514
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 9.601752304319639
```

---

### Case 25

**Description:** Run 25: args=7, 6, 7, 291.028562513281


**Input:**

```
7
6
7
291.028562513281
```

**Expected Output:**

```
Geef de dag van de week (1-7): Geef het uur van aankomst: Geef het aantal personen: Geef het totaalbedrag: Resultaat: 276.4771343876169
```

---
