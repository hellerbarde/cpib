
## Gedanken zur Syntax

*Warum so und nicht anders?*

Zur Syntax haben wir eine ausführliche Diskussion geführt, und dabei verschiedene Varianten ent- und wieder verworfen.

### Deklaration
Zum Vergleich zunächst die Deklaration einer Variablen, wie sie bereits in IML existiert:
var m:int32;
Zunächst wird deklariert, dass es eine Variable (und nicht eine Konstante) ist, dann wird sie benannt und dann der Typ angegeben. Wir wollten uns möglichst nahe an diese Vorgabe halten, da wir nicht einfach Teile einer anderen Sprache in IML einbauen wollten, sondern IML erweitern wollten   .

Unser erster Versuch, dies zu erreichen, sah so aus:

```
var a:TYPE[LENGTH][DIMENSION];
```

`TYPE` würde hier `int32` oder `BOOL` sein, und so bestimmen, was der Typ der Elemente im Array ist. Obwohl diese Schreibweise durchaus elegant ist, macht sie es unmöglich, mehrdimensionale Arrays zu deklarieren, welche nicht in allen Dimensionen gleich lang sind. Zudem ist diese Schreibweise noch sehr deutlich von Sprachen wie Java beeinflusst, und führt die eckigen Klammern neu ein.

Als nächste Schreibweise überlegten wir uns, die folgende zu Verwenden:

```
var b:array (array_decl) LENGTH;
var b:array (array (array (array int32 8) 5) 3) 10;
var b:array int32 3;
```

Während dies für ein eindimensionales Array uns sehr intuitiv erscheint, wird es für mehrdimensionale Arrays eher verwirrend, da die Längenangaben dann in der "verkehrten" Reihenfolge dastehen. 
Daher modifizierten wir diese Schreibweise und verlegten die Länge nach vorne:

```
var c:array LENGTH (array_decl);
const c:array 10 (array 5 (array 6 (array 2 int32)));
var c:array 3 int32;
```

Statt einem "Array von ints mit Länge 3" würde man also ein "Array, Länge 3, von ints" deklarieren. Dies schien uns nur wenig unintuitiver, und bei mehrdimensionalen Arrays deutlich besser. Ganz zufrieden waren wir aber noch nicht. Klammern zur Verschachtelung werden nämlich ab einigen Levels von Verschachtelung immer schlechter lesbar.

Da alle nicht-Array Elemente eines Arrays vom gleichen Typ sind, und das einzige verschachtelbare Arrays sind, kamen wir darauf, die Redundanzen zu entfernen:

```
var d:array (4,10,5) int32;
const d:array (3) int32;
```

Die Länge der einzelnen Dimensionen ist das einzige, was sie unterscheidet und mit dieser Deklaration nutzen wir dies.

Die meisten unserer Beispiele verwenden var, da wir dies für den häufigsten Anwendungsfall halten, aber natürlich kann man auch konstante Arrays nutzen, um zum Beispiel eine fixe Wahrheitstabelle abzubilden.

```
const e:array (4, 2) bool;
e init := [[true, true], [true, false], [false, true], [false, false]];
```


### Array Initialisierung und Zugriff

Beim Initialisieren der Arrays haben wir uns sofort dafür entschieden, dass ein Array immer vollständig initialisiert werden muss, d.h. nicht teilweise unbestimmte Werte haben darf. Wir haben uns aber überlegt, dass es nützlich sein könnte, Arrays leicht mit dem Wert 0 zu initialisieren. Dazu haben wir die folgende Syntax entworfen und das Keyword 'fill' eingeführt. Hier haben wir die eckigen Klammern dann doch eingeführt, da uns die Syntax mit ihnen genug deutlich besser lesbar vorkam.

```
var a: array (7) int32;
var b: array (3) int32;
a init := [0, 1, 2, 3, 4, 5, 6];
b init := fill 0;
```

Bei erneuter Betrachtung haben wir keinen Grund gefunden, warum unsere Array nur "nullbar" sein sollten, und erlauben nun, ein Array komplett mit einem beliebigen Wert aufzufüllen, welcher auch durch eine Expression repräsentiert sein könnte.

```
var c: array (6) int32;
c init := fill 5*3+1;
```

Beim Zugriff haben wir uns für eine Schreibweise entschieden, wie sie in verschiedenen anderen Sprachen verwendet wir, da sie uns gefällt, und so möglichst vielen Benutzern bekannt sein sollte. Wir indizieren aus demselben Grund auch von 0 aus und erlauben keine negativen Indices. Auch bei den Slices kommen negative Werte nicht vor. Ein weiterer Vorteil des 0-basierten Index zeigt sich dann auch in der Codegeneration, beim Berechnen des Speicher-Offsets.

```
var d: array (4,2) bool;
d init := [[true, true],[true, false],[false, true],[false,false]];
```

Dann hat `a[0]` den Inhalt `[true, true]`, und `a[0][1]` den Wert true.

Bevor wir nun zu den Array Slices kommen, sollte noch erwähnt werden, dass wir auch Array-Literale einführen, wie bei der Array-Initialisierung bereits gezeigt.

### Array Slice Notation

Ein Array Slice ist ein erweiterter Zugriff, und soll auf möglichst simple Art erlauben, mehrere Elemente gleichzeitig zu adressieren. Daher übernahmen wir grundsätzlich die Syntax eines Array-Zugriffs, und erweiterten sie um ein Trennsymbol, '..', und einen zweiten Index. Wir beschreiben Slices also über einen Start- und einen End-Index. In unserem Fall sind beide *inklusive* zu verstehen.

```
var a: array (20) int32;
var b: array (4) int32;
> snip
b := a[0..3]; 
```
In diesem Beispiel nehmen wir daher die ersten vier Elemente eines 20-Element Arrays, und füllen sie in einen 4-Element Array. Das bedingt auch, dass Arrays nicht nur Array-Literale zugewiesen werden können, sondern auch Array-Slices, wobei die Länge und der Typ natürlich korrekt sein müssen.

Zudem sollten Slice zu Slice Zuweisungen möglich sein, also z.B:

```
var c: array (20) int32;
var d: array (10) int32;
> snip
d[5..8] := c[16..20]; 
```
