# -*- coding: utf-8 -*-
"""
Created on Thu Dec 25 23:19:43 2014

@author: phil, mark
"""
import sys
import GrammarParser
if len(sys.argv) != 2:
    print ("Usage: python3 generate.py <path_to_file> \n")
else:
    GRAMMAR_FILE = open(sys.argv[1], 'r')
    INPUT_STRING = GRAMMAR_FILE.read()
    print("{{\n{}\n}}".format(
        ",\n".join([repr(x) for x in GrammarParser.parse_parse_table(INPUT_STRING)])))
