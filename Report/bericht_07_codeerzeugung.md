## Bytecode
Warum nennen wir es bytecode?

### Allgemeine Codeerzeugung
Die Codeerzeugung geschieht bei uns über den Abstract Syntax Tree, indem der Wurzel, dem ASTProgram, der Befehl zur Codeerzeugung erteilt wird.
Danach generieren die Knoten des AST mit Hilfe der Kontextinformation des Checkers ihren jeweiligen Code, welcher zusammen mit einer String-Repräsentation abgespeichert wird. Die Kontextinformationen werden dazu genutzt, beispielsweise Adressen von Variablen abzuspeichern oder Jumps zu berechnen.
Ein Integer-Literal erzeugt also seinen eigenen ``` intLoad(value) ``` Befehl.

### Speicherlayout
Im ersten Ansatz, welcher in der Version der Gruppe 06 weiter verwendet wird, wird bei der Allokation von Speicherplatz und Adressen die Grösse einer Variable nicht beachtet. Das macht den Code sehr schön, und da ein Integer, Boolean oder Decimal jeweils nur einen Platz auf dem Stack benötigt, funktioniert dieser Ansatz fehlerfrei.
Bei Arrays, welche sich über mehrere Stackplätze hinziehen, führt aber dies zu Speicherplatzverletzungen. Daher mussten wir noch eine Size() Funktion für Deklarationen einführen, mit welcher die benötigten Stackplätze ermittelt und respektiert werden konnten.
Die Size-Funktion ist auch für mehrdimensionale Arrays nutzbar, da sie mittels FoldLeft alle Dimensionen miteinander multipliziert und so die gesamte Kapazität des Arrays findet.

Ein Array wird bei uns so im Speicher abgelegt, dass das erste Element an der Stelle mit dem niedrigsten Stackindex liegt. Die Adresse des Arrays zeigt so ebenfalls auf dieses erste Element. Das erleichterte uns die Überlegungen beim Schreiben des Arrayzugriffs, da so der Index einfach als Offset dienen kann. 
Wird ein bestehendes Array auf den Stack geladen, so wird es wieder in dieser Reihenfolge geladen, da es ja eventuell in eine lokale Kopie geladen wird. Positiver Nebeneffekt davon ist, dass die Umkehr eines Arrays eine triviale Operation geworden ist, bei der ein Array geladen wird, und dann einfach alle Elemente vom Stack gelesen werden können.

### Erweiterung der VM

Um unsere Arrays zu implementieren, mussten wir auch die VM erweitern, was dank Herrn Peyers Effort, sie nach C# zu portieren, zügig machbar war.
Wir mussten zwei neue Methoden einführen:
ArrayOutput, um Arrays sauber ausgeben zu können, und ArrayAccess, um Array Slicing umzusetzen.
ArrayOutput nimmt als zusätzliches Argument im Vergleich zu allen anderen Outputmethoden die Länge des Arrays an, um so das ganze Array ausgeben zu können. 
ArrayAccess haben wir so implementiert, dass wir zunächst drei Werte auf den Stack laden:
* Die Adresse des Arrays, auf welches wir zugreifen wollen.
* Der Startindex
* Der Endindex
ArrayAccess() liest diese drei Werte und übernimmt gleich noch die Prüfung, dass der Startindex vor dem Endindex liegt und lädt dann alle Werte auf den Stack, wie unter Speicherlayout beschrieben.


