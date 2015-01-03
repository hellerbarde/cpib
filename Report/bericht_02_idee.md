## Abstract

IML hat ursprünglich keine Datenstrukturen wie Tupel, Listen und Arrays. Wir wollten uns dem Thema Arrays annehmen. Uns war es vorallem wichtig, einige Gedanken zu konsistentem, intuitivem und lesbarem Syntax festzuhalten. Zu finden ist dies im nächsten Kapitel "Gedanken zum Syntax". 

Array Slicing ist das andere Thema, das uns interessiert hat. Es ist eine Spracherweiterung, die es ermöglicht mit wenig Quellcode einen Teil eines Arrays zu extrahieren und weiterzuverwenden. Beispielsweise so:

```
a := [3,1,4,1,5,9]
b := a[1..4]
```

In diesem Beispiel wird zuerst der Variable `a` ein Arrayliteral zugewiesen. Danach wird der Variable `b` eine Teilkopie von a zugewiesen. Spezifisch wäre es hier `[1,4,1,5]`. Diese syntaktische Abkürzung ermöglicht es einem, seinen Quellcode sehr konzis und intuitiv zu gestalten. 

Wir haben noch ein paar weitere syntaktische Abkürzungen einbezogen, die es einem vereinfachen mit Arrays zu arbeiten. Zum Beispiel das Auffüllen von Arrays mit einem spezifizierten Wert. Die lexikalische und syntaktische Spezifikation sind in den respektiven Kapiteln zu finden. 
