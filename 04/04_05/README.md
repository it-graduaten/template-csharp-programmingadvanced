# 04_05

Een school wil een systeem bouwen om studenten te registreren en hun stemmen bij te houden. De school heeft exact twee kandidaat-borgmeesters: Anna en Bart.

Gebruik een List<string> om de namen van de gestemden bij te houden.

Vraag de gebruiker eerst hoeveel studenten er gaan stemmen. Vervolgens vraag je voor elke student:
1. De naam van de student.
2. Voor welke kandidaat ze stemmen (Anna of Bart).

Sla de naam van elke student op in de lijst. Tel ook het aantal stemmen voor Anna en Bart apart bij.

Tonen na alle stemmen: het totaal aantal stemmen, het aantal stemmen voor Anna, het aantal stemmen voor Bart, en wie gewonnen heeft.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=1, IWwvj, bart, hJ09p, bart, 1gJMD, bart


**Input:**

```
1
IWwvj
bart
hJ09p
bart
1gJMD
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 1
Stemmen voor Anna: 0
Stemmen voor Bart: 1
Bart heeft gewonnen!
```

---

### Case 2

**Description:** Run 2: args=2, KYYtk, bart, tLnbD, bart, iWmmc, bart


**Input:**

```
2
KYYtk
bart
tLnbD
bart
iWmmc
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 2
Stemmen voor Anna: 0
Stemmen voor Bart: 2
Bart heeft gewonnen!
```

---

### Case 3

**Description:** Run 3: args=3, RxwL9, anna, UsTek, bart, pgY7z, anna


**Input:**

```
3
RxwL9
anna
UsTek
bart
pgY7z
anna
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 3: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 3
Stemmen voor Anna: 2
Stemmen voor Bart: 1
Anna heeft gewonnen!
```

---

### Case 4

**Description:** Run 4: args=2, f478u, anna, vhRSb, anna, H3pzX, bart


**Input:**

```
2
f478u
anna
vhRSb
anna
H3pzX
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 2
Stemmen voor Anna: 2
Stemmen voor Bart: 0
Anna heeft gewonnen!
```

---

### Case 5

**Description:** Run 5: args=2, 6tqHi, bart, RT2LF, anna, FDKUS, anna


**Input:**

```
2
6tqHi
bart
RT2LF
anna
FDKUS
anna
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 2
Stemmen voor Anna: 1
Stemmen voor Bart: 1
Het is een gelijke stand!
```

---

### Case 6

**Description:** Run 6: args=3, 6bN0d, bart, XrhvV, bart, KC3ie, bart


**Input:**

```
3
6bN0d
bart
XrhvV
bart
KC3ie
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 3: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 3
Stemmen voor Anna: 0
Stemmen voor Bart: 3
Bart heeft gewonnen!
```

---

### Case 7

**Description:** Run 7: args=2, BqddO, anna, eXsXZ, bart, RUvO9, anna


**Input:**

```
2
BqddO
anna
eXsXZ
bart
RUvO9
anna
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 2
Stemmen voor Anna: 1
Stemmen voor Bart: 1
Het is een gelijke stand!
```

---

### Case 8

**Description:** Run 8: args=3, 8pD0U, bart, owkHV, anna, rAc1J, bart


**Input:**

```
3
8pD0U
bart
owkHV
anna
rAc1J
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 3: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 3
Stemmen voor Anna: 1
Stemmen voor Bart: 2
Bart heeft gewonnen!
```

---

### Case 9

**Description:** Run 9: args=3, h2GOq, anna, tbr6s, bart, yiXrC, bart


**Input:**

```
3
h2GOq
anna
tbr6s
bart
yiXrC
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 3: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 3
Stemmen voor Anna: 1
Stemmen voor Bart: 2
Bart heeft gewonnen!
```

---

### Case 10

**Description:** Run 10: args=3, 0oelB, anna, QRgn4, bart, cMoOD, bart


**Input:**

```
3
0oelB
anna
QRgn4
bart
cMoOD
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 3: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 3
Stemmen voor Anna: 1
Stemmen voor Bart: 2
Bart heeft gewonnen!
```

---

### Case 11

**Description:** Run 11: args=3, OCfZf, anna, Q4yqh, bart, GzzQc, anna


**Input:**

```
3
OCfZf
anna
Q4yqh
bart
GzzQc
anna
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 3: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 3
Stemmen voor Anna: 2
Stemmen voor Bart: 1
Anna heeft gewonnen!
```

---

### Case 12

**Description:** Run 12: args=3, b9o5O, anna, 4YwV9, bart, nDQZf, anna


**Input:**

```
3
b9o5O
anna
4YwV9
bart
nDQZf
anna
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 3: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 3
Stemmen voor Anna: 2
Stemmen voor Bart: 1
Anna heeft gewonnen!
```

---

### Case 13

**Description:** Run 13: args=2, WIMYG, anna, Gnefm, anna, GWoh1, anna


**Input:**

```
2
WIMYG
anna
Gnefm
anna
GWoh1
anna
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 2
Stemmen voor Anna: 2
Stemmen voor Bart: 0
Anna heeft gewonnen!
```

---

### Case 14

**Description:** Run 14: args=3, ESh5J, bart, lj2pf, anna, lgGrG, bart


**Input:**

```
3
ESh5J
bart
lj2pf
anna
lgGrG
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 3: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 3
Stemmen voor Anna: 1
Stemmen voor Bart: 2
Bart heeft gewonnen!
```

---

### Case 15

**Description:** Run 15: args=2, Ibk2s, bart, sgGih, bart, w1HLk, bart


**Input:**

```
2
Ibk2s
bart
sgGih
bart
w1HLk
bart
```

**Expected Output:**

```
Hoeveel studenten gaan stemmen? Naam van student 1: Voor welke kandidaat stem je? (Anna/Bart): Naam van student 2: Voor welke kandidaat stem je? (Anna/Bart): Totaal aantal stemmen: 2
Stemmen voor Anna: 0
Stemmen voor Bart: 2
Bart heeft gewonnen!
```

---
