# 04_10

Een school wil een systeem bouwen om de resultaten van een examen te bekijken. Er zijn exact vijf studenten die de toets hebben gemaakt.

Gebruik een int-array om de scores op te slaan. Vraag de gebruiker om de score van elke student in te voeren (een geheel getal tussen 0 en 100).

Tonen na het invoeren van alle scores:
- De hoogste score en de naam van de student met de hoogste score (de studentenamen zijn: "Student A", "Student B", "Student C", "Student D", "Student E").
- De laagste score en de naam van de student met de laagste score.
- Het gemiddelde van alle scores.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=36, 71, 46, 77, 91


**Input:**

```
36
71
46
77
91
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 91 van Student E.
De laagste score is 36 van Student A.
Het gemiddelde is 64.2.
```

---

### Case 2

**Description:** Run 2: args=62, 16, 89, 72, 52


**Input:**

```
62
16
89
72
52
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 89 van Student C.
De laagste score is 16 van Student B.
Het gemiddelde is 58.2.
```

---

### Case 3

**Description:** Run 3: args=51, 48, 21, 9, 7


**Input:**

```
51
48
21
9
7
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 51 van Student A.
De laagste score is 7 van Student E.
Het gemiddelde is 27.2.
```

---

### Case 4

**Description:** Run 4: args=62, 75, 28, 22, 45


**Input:**

```
62
75
28
22
45
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 75 van Student B.
De laagste score is 22 van Student D.
Het gemiddelde is 46.4.
```

---

### Case 5

**Description:** Run 5: args=4, 98, 89, 73, 91


**Input:**

```
4
98
89
73
91
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 98 van Student B.
De laagste score is 4 van Student A.
Het gemiddelde is 71.
```

---

### Case 6

**Description:** Run 6: args=62, 74, 91, 14, 77


**Input:**

```
62
74
91
14
77
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 91 van Student C.
De laagste score is 14 van Student D.
Het gemiddelde is 63.6.
```

---

### Case 7

**Description:** Run 7: args=90, 74, 47, 78, 90


**Input:**

```
90
74
47
78
90
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 90 van Student A.
De laagste score is 47 van Student C.
Het gemiddelde is 75.8.
```

---

### Case 8

**Description:** Run 8: args=26, 41, 5, 52, 2


**Input:**

```
26
41
5
52
2
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 52 van Student D.
De laagste score is 2 van Student E.
Het gemiddelde is 25.2.
```

---

### Case 9

**Description:** Run 9: args=2, 18, 98, 64, 13


**Input:**

```
2
18
98
64
13
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 98 van Student C.
De laagste score is 2 van Student A.
Het gemiddelde is 39.
```

---

### Case 10

**Description:** Run 10: args=68, 100, 5, 23, 18


**Input:**

```
68
100
5
23
18
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 100 van Student B.
De laagste score is 5 van Student C.
Het gemiddelde is 42.8.
```

---

### Case 11

**Description:** Run 11: args=71, 83, 0, 34, 12


**Input:**

```
71
83
0
34
12
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 83 van Student B.
De laagste score is 0 van Student C.
Het gemiddelde is 40.
```

---

### Case 12

**Description:** Run 12: args=68, 61, 2, 92, 47


**Input:**

```
68
61
2
92
47
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 92 van Student D.
De laagste score is 2 van Student C.
Het gemiddelde is 54.
```

---

### Case 13

**Description:** Run 13: args=72, 1, 48, 45, 10


**Input:**

```
72
1
48
45
10
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 72 van Student A.
De laagste score is 1 van Student B.
Het gemiddelde is 35.2.
```

---

### Case 14

**Description:** Run 14: args=72, 17, 35, 45, 25


**Input:**

```
72
17
35
45
25
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 72 van Student A.
De laagste score is 17 van Student B.
Het gemiddelde is 38.8.
```

---

### Case 15

**Description:** Run 15: args=87, 58, 75, 92, 62


**Input:**

```
87
58
75
92
62
```

**Expected Output:**

```
Geef score van Student A: Geef score van Student B: Geef score van Student C: Geef score van Student D: Geef score van Student E: De hoogste score is 92 van Student D.
De laagste score is 58 van Student B.
Het gemiddelde is 74.8.
```

---
