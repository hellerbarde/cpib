cpib
====

my solutions for cpib (compiler) at fhnw

To make a pdf from our md:

`pandoc -f markdown_github -t latex -o bericht.pdf bericht_*.md`

or 

`pandoc -f markdown_github -t latex --standalone -o bericht.tex bericht_*.md && pdflatex bericht.tex`