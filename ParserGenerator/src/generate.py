#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Thu Dec 25 23:19:43 2014

@author: phil, mark
"""
import sys
import GrammarParser
import CodeGenerator
if len(sys.argv) != 3:
    print("Usage: {executable} <path_to_file> <output_folder>\n".format(executable=sys.argv[0]))
else:
    GRAMMAR_FILE = open(sys.argv[1], 'r')
    OUTPUT_FOLDER = sys.argv[2]
    INPUT_STRING = GRAMMAR_FILE.read()
    parse_table = GrammarParser.parse_parse_table(INPUT_STRING)
    if __debug__:
        print("{{\n{}\n}}".format(
            ",\n".join([repr(x) for x in parse_table])))

    result = CodeGenerator.generate(parse_table, "./"+OUTPUT_FOLDER)
    if result:
        print("Success")
    else:
        print("Success, probably")
