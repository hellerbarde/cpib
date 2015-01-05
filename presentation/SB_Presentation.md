# Sprachdesign

## Arrays und Array-Slicing

* Bekannte Datenstruktur

```
var a:array (5) int;

a[5];
```

* Extraktion eines Teilarrays

```
a := [1,2,3,4,5];

print(a[0..3]);

--------------------
output => [1,2,3,4]
```
## Lexikalische Erweiterungen

* Nur weniges nötig
* `FILL` für den syntaktischen Zucker
* `RANGE` damit wir Minus nicht überladen

Pattern                        | Token
-------------------            |--------------------
`[`                            | LBRACKET
`]`                            | RBRACKET
`fill`                         | FILL
`array`                        | ARRAY
`..`                           | RANGE

## Grammatikalische Produktionen

```
cmd     ::= SKIP
          | expr ':=' [FILL] expr
          [...]
typedIdent ::= IDENT ':'(ATOMTYPE 
              | ARRAY '(' expr {',' expr} ')' TYPE)
factor ::= LITERAL
         | arrayLiteral
         | IDENT [INIT | exprList | arrayIndex]
         [...]

arrayIndex::= '[' expr ['..' expr] ']' {arrayIndex}
arrayLiteral ::= '[' arrayContent ']'
arrayContent ::= LITERAL {',' LITERAL}
               | arrayLiteral {',' arrayLiteral}
```

# Erreichtes und Demo

## Erreichte Ziele

* Generell IML
    * Variablen, global und lokal
    * Prozeduren und Funktionen
    * Kontrollstrukturen
* Arrays
	* Input und Output
	* Zugriff auf Elemente
	* 
	* Literale
    * Fixed-Length Slices


## Bubble Sort

Demonstration

# Implementation

## Abstract Syntax Tree und Code Generation

### AST 

* There is an AST and a 

### Code Generation

## VM Erweiterungen

* ArrayInput und -Output
    * Länge als Argument
* ArrayAccess:
  Nimmt 3 Werte vom Stack
    * Adresse des Arrays
    * Start-Index
    * End-Index
Lädt so bestimmten Teil des Arrays auf den Stack

# Abschliessendes

## Rückblick

* Viel gelernt
    * Genug um einiges anders machen zu wollen
* Selbst mit Warnung vom Professor Aufwand unterschätzt

* Keine dynamischen Array Slices
    * Passt konzeptuell nicht zu IML
* Arrays auf Heap ablegen
    * Viel zu spät realisiert
    * Hat ein paar Sachen erleichtert
    * Hat vieles verkompliziert


## Ausblick

* AST neu planen
    * Würde Code Generation erleichtern

## Fragen

Vielen Dank! 

![Foo](latenights.png)