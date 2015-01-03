
## Kontext- und Typeinschränkung

Bei Arrays wie wir sie hier definiert haben, kommen keine neuartigen Typ- oder Kontexteinschränkungen dazu. Soll ein Element eines Arrays gesetzt werden, so muss der Typ des neuen Wertes zum Typ des Arrays passen und umgekehrt kann ein int-Literal nie durch ein Array ersetzt werden, sondern höchstens durch ein Element eines Arrays. Zudem könne in einem Array immer nur entweder weitere Arrays oder Literale enthalten sein. Bei einem multi-dimensionalen Array sind also alle Dimensionen bis zur letzen nur mit Arrays befüllt.
Nur beim Slicing kommt ein neuer Check hinzu, es müssen nämlich die Längen der Slices überprüft werden. Dies kann z.T. zur Compile-Zeit geschehen, aber, da wir auch Expressions zulassen beim Beschreiben eines Slices, nicht ausschliesslich.

Checks von konstanten etc.
