
# Abstract


# Idee

# Syntax 

## Lexikalisch
Generic variable decl:
var m:int;
var n:int;

var a:TYPE[LENGTH][DIMENSION] -  no

var b:arr TYPE LEN; - how nest?
var c:arr int 45;

var d:arr LENGTH (array_decl);
var d:arr 10 (arr 5 (arr 6 (arr 2 int)));

var e:arr (array_decl) LENGTH;
var e:arr (arr (arr (arr int 8) 5) 3) 10;

WIP Deklaration:
var f:arr (4,10,5) int;

WIP Array Initialisierung und Zugriff:
// Arrays müssen vollständig initialisiert werden; sugar für init:= 0;
var a: arr 7 int;
var foo: int;
a init := [0, 1, 2, 3, 4, 5, 6];
foo init := a[0];

WIP Array Init und Zugriff bei verschachtelten Arrays:
var a: arr (4,2) bool;
a init:= [[true, true],[true, false],[false, true],[false,false]];
a[0] = [true, true];
a[0][1] = true; \\ this gets REAL ugly if you go several levels deep


WIP Array Deklaration mit Array Literalen:
var a: arr 4 int;
<snip>
a := [0, 1, 5, 6];

WIP Array Slice Notation:
var a: arr 20 int;
var b: arr 4 int;
b := a[1:3]; // the indices are both inclusive, making this a 3

WIP Array Zuweisungen:
a[0] := EXPR;
a[0:2] := ARR_EXPR;


## Grammatikalisch

# Kontext- und Typeinschränkung


# Codeerzeugung (Final Report only)
--- EMPTY FOR NOW ---

# Vergleich mit anderen Sprachen
Matlab: Schrittlänge
Python: Slice notation, aber inklusive
??: ++ als concatenation


# Warum so und nicht anders?
Maximale Lesbarkeit ohne Unklarheit und ohne die Typsicherheit zu verletzen.
Wir haben uns ueberlegt, Arrays auch mit basic types zu konkatenieren. Dies fuehrt aber zu einer komplexeren Grammatik. Da wir Array Literale haben, kann ein basic type ohne grossen Aufwand manuell in ein Array verpackt werden.


# Appendix: Testprogramme


Gewichtung abhängig von Thema





 Notes
=======

var a: arr <20> int
var a: arr <20

var a: arr 20 x int

** Array creation

** Array slice notation in Python
ford% python
Python 2.7.8 (default, Jul 25 2014, 14:04:36)
[GCC 4.8.3] on cygwin
Type "help", "copyright", "credits" or "license" for more information.
>>> a = [0,1,2,3,4,5,6]
>>> a[0:2]
[0, 1]
>>> a[0:6]
[0, 1, 2, 3, 4, 5]
>>> a[0:7]
[0, 1, 2, 3, 4, 5, 6]
>>>





** Array declaration (with 


Table exmaple

Left-Aligned  | Center Aligned  | Right Aligned 
:------------ |:---------------:| -----:
col 3 is      | some wordy text | $1600 
col 2 is      | centered        |   $12 
zebra stripes | are neat        |    $1 

