# 03_10

Schrijf een programma dat een e-mailadres valideert volgens de volgende regels:

- Het e-mailadres moet minstens 5 karakters lang zijn.
- Het e-mailadres moet een @ bevatten.
- Er moet een punt (.) na de @ staan.
- De extensie na het laatste punt moet een geldige domeinextensie zijn: .be, .nl, .com of .org.

Vraag de gebruiker om een e-mailadres en controleer het op geldigheid. Toon "Geldig e-mailadres" als alle regels voldaan zijn, of een specifieke foutmelding voor elke overtreding.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=info@organisatie.org


**Input:**

```
info@organisatie.org
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 2

**Description:** Run 2: args=.....@.....com


**Input:**

```
.....@.....com
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 3

**Description:** Run 3: args=hello@world.org


**Input:**

```
hello@world.org
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 4

**Description:** Run 4: args=.....@.....com


**Input:**

```
.....@.....com
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 5

**Description:** Run 5: args=name@domain.com


**Input:**

```
name@domain.com
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 6

**Description:** Run 6: args=test@


**Input:**

```
test@
```

**Expected Output:**

```
Geef een e-mail adres: Ongeldig e-mailadres. Geen punt na @ gevonden.
```

---

### Case 7

**Description:** Run 7: args=a@b.be


**Input:**

```
a@b.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 8

**Description:** Run 8: args=test@.be


**Input:**

```
test@.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 9

**Description:** Run 9: args=info@organisatie.org


**Input:**

```
info@organisatie.org
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 10

**Description:** Run 10: args=test@


**Input:**

```
test@
```

**Expected Output:**

```
Geef een e-mail adres: Ongeldig e-mailadres. Geen punt na @ gevonden.
```

---

### Case 11

**Description:** Run 11: args=student@school.nl


**Input:**

```
student@school.nl
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 12

**Description:** Run 12: args=student@school.nl


**Input:**

```
student@school.nl
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 13

**Description:** Run 13: args=test@example.com


**Input:**

```
test@example.com
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 14

**Description:** Run 14: args=a@b.be


**Input:**

```
a@b.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 15

**Description:** Run 15: args=@test.be


**Input:**

```
@test.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 16

**Description:** Run 16: args=a@b.be


**Input:**

```
a@b.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 17

**Description:** Run 17: args=.....@.....com


**Input:**

```
.....@.....com
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 18

**Description:** Run 18: args=a@b.c


**Input:**

```
a@b.c
```

**Expected Output:**

```
Geef een e-mail adres: Ongeldige e-mail extensie.
```

---

### Case 19

**Description:** Run 19: args=a@b.be


**Input:**

```
a@b.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 20

**Description:** Run 20: args=test@test.be


**Input:**

```
test@test.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 21

**Description:** Run 21: args=hello@world.org


**Input:**

```
hello@world.org
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 22

**Description:** Run 22: args=test@test.be


**Input:**

```
test@test.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 23

**Description:** Run 23: args=joren@thomasmore.be


**Input:**

```
joren@thomasmore.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 24

**Description:** Run 24: args=a@b.be


**Input:**

```
a@b.be
```

**Expected Output:**

```
Geef een e-mail adres: Geldig e-mailadres
```

---

### Case 25

**Description:** Run 25: args=test@example.eu


**Input:**

```
test@example.eu
```

**Expected Output:**

```
Geef een e-mail adres: Ongeldige e-mail extensie.
```

---
