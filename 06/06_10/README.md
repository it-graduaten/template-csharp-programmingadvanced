# 06_10

Maak een programma dat de gebruiker vraagt om namen en leeftijden van personen in te voeren. De gebruiker stopt door als leeftijd 0 in te voeren. Het programma toont daarna het totaal aantal personen, de gemiddelde leeftijd van alle personen, en hoeveel personen ouder zijn dan 30 jaar.

## Fuzz Test Cases

Below are the automatically generated input/output expectations.

---

### Case 1

**Description:** Run 1: args=Maria, 24, David, 80, Magdalena, 57, Lisa, 38, Michel, 0


**Input:**

```
Maria
24
David
80
Magdalena
57
Lisa
38
Michel
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 4
Gemiddelde leeftijd: 49.75
Personen ouder dan 30: 3
```

---

### Case 2

**Description:** Run 2: args=Catharina, 36, Maarten, 23, Hilde, 0


**Input:**

```
Catharina
36
Maarten
23
Hilde
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 2
Gemiddelde leeftijd: 29.5
Personen ouder dan 30: 1
```

---

### Case 3

**Description:** Run 3: args=Christophe, 75, Margot, 0


**Input:**

```
Christophe
75
Margot
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 1
Gemiddelde leeftijd: 75
Personen ouder dan 30: 1
```

---

### Case 4

**Description:** Run 4: args=Kelly, 60, Casper, 36, Yasmine, 0


**Input:**

```
Kelly
60
Casper
36
Yasmine
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 2
Gemiddelde leeftijd: 48
Personen ouder dan 30: 2
```

---

### Case 5

**Description:** Run 5: args=Christine, 27, Koen, 67, Frederic, 1, Nathan, 0


**Input:**

```
Christine
27
Koen
67
Frederic
1
Nathan
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 3
Gemiddelde leeftijd: 31.666666666666668
Personen ouder dan 30: 1
```

---

### Case 6

**Description:** Run 6: args=Tania, 5, Maria, 79, Godelieve, 38, Ronald, 57, Rudy, 0


**Input:**

```
Tania
5
Maria
79
Godelieve
38
Ronald
57
Rudy
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 4
Gemiddelde leeftijd: 44.75
Personen ouder dan 30: 3
```

---

### Case 7

**Description:** Run 7: args=Wim, 25, Ella, 29, Imane, 58, Ivan, 62, Wim, 41, Jasper, 0


**Input:**

```
Wim
25
Ella
29
Imane
58
Ivan
62
Wim
41
Jasper
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 5
Gemiddelde leeftijd: 43
Personen ouder dan 30: 3
```

---

### Case 8

**Description:** Run 8: args=Annemie, 68, Luc, 54, Ann, 53, Anneleen, 64, Herman, 11, Linda, 0


**Input:**

```
Annemie
68
Luc
54
Ann
53
Anneleen
64
Herman
11
Linda
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 5
Gemiddelde leeftijd: 50
Personen ouder dan 30: 4
```

---

### Case 9

**Description:** Run 9: args=Arthur, 50, Jonathan, 58, Pascal, 55, Antonio, 64, Adriana, 63, Joanna, 0


**Input:**

```
Arthur
50
Jonathan
58
Pascal
55
Antonio
64
Adriana
63
Joanna
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 5
Gemiddelde leeftijd: 58
Personen ouder dan 30: 5
```

---

### Case 10

**Description:** Run 10: args=Pierre, 29, Walter, 0


**Input:**

```
Pierre
29
Walter
0
```

**Expected Output:**

```
Geef de naam van een persoon (0 = einde):
Geef de leeftijd van {naam}:
Geef de naam van de volgende persoon (0 = einde):
Geef de leeftijd van {naam}:
Aantal personen: 1
Gemiddelde leeftijd: 29
Personen ouder dan 30: 0
```

---
