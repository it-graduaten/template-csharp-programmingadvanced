# 03_06

Een parkeringszone hanteert de volgende tarieven:

- Zone A: 2 euro per uur.
- Zone B: 1,50 euro per uur.
- Zone C: 1 euro per uur.

Daarnaast geldt:

- Voor parkeren van minder dan 1 uur betaalt men geen tarief.
- Voor parkeren van 1 tot 4 uur betaalt men het uurtarief.
- Voor parkeren van meer dan 4 uur betaalt men een maximum van 10 euro.

Vraag de gebruiker om de zone (A, B of C) en het aantal geparkeerde uren. Toon het te betalen bedrag.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=A, 5


**Input:**

```
A
5
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 10
```

---

### Case 2

**Description:** Run 2: args=A, 5


**Input:**

```
A
5
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 10
```

---

### Case 3

**Description:** Run 3: args=A, 3


**Input:**

```
A
3
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 6
```

---

### Case 4

**Description:** Run 4: args=C, 3


**Input:**

```
C
3
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 3
```

---

### Case 5

**Description:** Run 5: args=C, 5


**Input:**

```
C
5
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 5
```

---

### Case 6

**Description:** Run 6: args=B, 5


**Input:**

```
B
5
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 7.5
```

---

### Case 7

**Description:** Run 7: args=B, 6


**Input:**

```
B
6
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 9
```

---

### Case 8

**Description:** Run 8: args=B, 3


**Input:**

```
B
3
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 4.5
```

---

### Case 9

**Description:** Run 9: args=B, 6


**Input:**

```
B
6
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 9
```

---

### Case 10

**Description:** Run 10: args=B, 1


**Input:**

```
B
1
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 1.5
```

---

### Case 11

**Description:** Run 11: args=C, 3


**Input:**

```
C
3
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 3
```

---

### Case 12

**Description:** Run 12: args=B, 1


**Input:**

```
B
1
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 1.5
```

---

### Case 13

**Description:** Run 13: args=B, 6


**Input:**

```
B
6
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 9
```

---

### Case 14

**Description:** Run 14: args=A, 3


**Input:**

```
A
3
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 6
```

---

### Case 15

**Description:** Run 15: args=B, 2


**Input:**

```
B
2
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 3
```

---

### Case 16

**Description:** Run 16: args=C, 2


**Input:**

```
C
2
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 2
```

---

### Case 17

**Description:** Run 17: args=C, 6


**Input:**

```
C
6
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 6
```

---

### Case 18

**Description:** Run 18: args=A, 8


**Input:**

```
A
8
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 10
```

---

### Case 19

**Description:** Run 19: args=B, 8


**Input:**

```
B
8
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 10
```

---

### Case 20

**Description:** Run 20: args=A, 7


**Input:**

```
A
7
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 10
```

---

### Case 21

**Description:** Run 21: args=B, 7


**Input:**

```
B
7
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 10
```

---

### Case 22

**Description:** Run 22: args=C, 5


**Input:**

```
C
5
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 5
```

---

### Case 23

**Description:** Run 23: args=B, 7


**Input:**

```
B
7
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 10
```

---

### Case 24

**Description:** Run 24: args=A, 0


**Input:**

```
A
0
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 0
```

---

### Case 25

**Description:** Run 25: args=C, 4


**Input:**

```
C
4
```

**Expected Output:**

```
Geef de zone (A, B of C): Geef het aantal geparkeerde uren: 4
```

---
