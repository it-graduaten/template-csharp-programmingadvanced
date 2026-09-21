# 03_07

Een bankautomaat vraagt de gebruiker om zijn pincode in te voeren. Als de pincode correct is (1234), vraagt de automaat om het opnamebedrag. Als het saldo (500 euro) voldoende is, wordt het geld uitgegeven en wordt het saldo verlaagd. Anders toont de automaat "Onvoldoende saldo." Als de pincode fout is, toont de automaat "Foute pincode."

Toon het nieuw saldo na de transactie.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=1234, 457


**Input:**

```
1234
457
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Uitbetaling van 457€ gaat door. Nieuw saldo: 43€
```

---

### Case 2

**Description:** Run 2: args=1234, 414


**Input:**

```
1234
414
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Uitbetaling van 414€ gaat door. Nieuw saldo: 86€
```

---

### Case 3

**Description:** Run 3: args=0147, 440


**Input:**

```
0147
440
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 4

**Description:** Run 4: args=1234, 499


**Input:**

```
1234
499
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Uitbetaling van 499€ gaat door. Nieuw saldo: 1€
```

---

### Case 5

**Description:** Run 5: args=1234, 460


**Input:**

```
1234
460
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Uitbetaling van 460€ gaat door. Nieuw saldo: 40€
```

---

### Case 6

**Description:** Run 6: args=0147, 483


**Input:**

```
0147
483
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 7

**Description:** Run 7: args=1234, 596


**Input:**

```
1234
596
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Onvoldoende saldo.
```

---

### Case 8

**Description:** Run 8: args=1234, 510


**Input:**

```
1234
510
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Onvoldoende saldo.
```

---

### Case 9

**Description:** Run 9: args=0147, 420


**Input:**

```
0147
420
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 10

**Description:** Run 10: args=0147, 493


**Input:**

```
0147
493
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 11

**Description:** Run 11: args=0147, 478


**Input:**

```
0147
478
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 12

**Description:** Run 12: args=0147, 404


**Input:**

```
0147
404
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 13

**Description:** Run 13: args=1234, 536


**Input:**

```
1234
536
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Onvoldoende saldo.
```

---

### Case 14

**Description:** Run 14: args=1234, 462


**Input:**

```
1234
462
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Uitbetaling van 462€ gaat door. Nieuw saldo: 38€
```

---

### Case 15

**Description:** Run 15: args=0147, 564


**Input:**

```
0147
564
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 16

**Description:** Run 16: args=0147, 412


**Input:**

```
0147
412
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 17

**Description:** Run 17: args=0147, 506


**Input:**

```
0147
506
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 18

**Description:** Run 18: args=1234, 427


**Input:**

```
1234
427
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Uitbetaling van 427€ gaat door. Nieuw saldo: 73€
```

---

### Case 19

**Description:** Run 19: args=0147, 597


**Input:**

```
0147
597
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 20

**Description:** Run 20: args=1234, 579


**Input:**

```
1234
579
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Onvoldoende saldo.
```

---

### Case 21

**Description:** Run 21: args=1234, 557


**Input:**

```
1234
557
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Onvoldoende saldo.
```

---

### Case 22

**Description:** Run 22: args=0147, 460


**Input:**

```
0147
460
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Foute pincode.
```

---

### Case 23

**Description:** Run 23: args=1234, 492


**Input:**

```
1234
492
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Uitbetaling van 492€ gaat door. Nieuw saldo: 8€
```

---

### Case 24

**Description:** Run 24: args=1234, 564


**Input:**

```
1234
564
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Onvoldoende saldo.
```

---

### Case 25

**Description:** Run 25: args=1234, 486


**Input:**

```
1234
486
```

**Expected Output:**

```
Geef je pincode (4 cijfers): Geef het bedrag dat je wil opnemen: Uitbetaling van 486€ gaat door. Nieuw saldo: 14€
```

---
