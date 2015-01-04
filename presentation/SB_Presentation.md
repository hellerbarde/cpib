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

# Umgesetztes und Demo

## Bubble Sort

# Abstract Syntax Tree und Code Generation

# VM Erweiterungen

# Lessons Learned oder Was würden wir anders machen beim nächsten Mal?

## Fragen

Vielen Dank! 
