
pdf: tex
	pdflatex  main.tex
	pdflatex  main.tex

tex:
	pandoc --slide-level 2 -t beamer SB_Presentation.md -o Presentation.tex

#pdfdirect:
#	pandoc --slide-level 2 -t beamer ZB_Presentation.md -o ZB_Presentation.pdf
	#-xdg-open talk.pdf
	# pandoc --toc --slide-level 2 -V theme:Frankfurt -t beamer talk.md -o talk.pdf

