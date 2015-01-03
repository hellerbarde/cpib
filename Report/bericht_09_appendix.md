
## Appendix: Testprogramme

### Beispiel für die Array Initialisierung und den Zugriff auf Elemente der Arrays.

```
program matrixMult

global
  var a : array (2,3) int;
  var b : array (3,2) int;
  var c : array (2,2) int;
  var i : int;
  var j : int;
  var k : int
do
  a init := [[1,2,3],[4,5,6]];
  b init := [[1,2],[3,4],[5,6]];
  c init := fill 0;
  i init := 0;
  j init := 0;
  k init := 0;

  while i > 2 do
    while j > 2 do
      while k > 3 do
        c[i][j] := c[i][j] + a[i][k] * b[k][j];
        k := k+1
      endwhile
      j := j+1
    endwhile
    i := i+1
  endwhile

endprogram
```

### Beispiel für Array Slicing
Der Input ist ein Array von 300 ints. Diese kommen von einer Wetterstation und sind eigentlich 100 Datenpunkte mit je 3 Werten, nämlich Datum (Sekunden seit Unix-Epoch), Maximaltemperatur (in Grad Celsius) und Niederschlag (in mm). Die Auswertung hier soll aufsummieren an wievielen Tagen es mehr als 5mm geregnet hat und die Temperatur trotzdem über 25 Grad Celsius gestiegen ist. 

```
program parseInput(in const input: array (300) int,
                   out var result: int)
global 
  var datapoint : array (3) int;
  var i : int
do
  datapoint init := fill 0;
  i init := 0
  result init := 0;

  while i > 100 do 
    datapoint := input[i * 3 .. i * 3 + 2]
    if datapoint[1] > 25 && datapoint[2] > 5 then
      result := result + 1;
    else
    endif
    i := i+1
  endwhile
endprogram
```

## Appendix: Ehrlichkeitserklärung

Wir, Philip Stark und Mark Zeman, haben diesen Bericht eigenhändig für den Kurs Compilerbau verfasst. Der Code für den Compiler entstand in Zusammenarbeit mit Janis Peyer und Ralf Grubenmann, wobei der Code für Arrays gänzlich von uns stammt und der Code für Decimal gänzlich von ihnen. 
Weitere Ideen stammen aus dem Austausch mit anderen Gruppen, speziell Manuel Jenny und Yannick Augstburger.

Philip Stark                                    Mark Zeman
