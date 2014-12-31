#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Thu Dec 25 23:19:43 2014

@author: phil, mark
"""
import sys
import GrammarParser
import CodeGenerator
if len(sys.argv) != 5:
    print("Usage: {executable} <path_to_file> <output_parser> <output_interfaces> <output_implementations>\n".format(executable=sys.argv[0]))
else:
    GRAMMAR_FILE = open(sys.argv[1], 'r')
    OUTPUT_PARSER = sys.argv[2]
    OUTPUT_INTERFACES = sys.argv[3]
    OUTPUT_IMPLEMENTATIONS = sys.argv[4]
    INPUT_STRING = GRAMMAR_FILE.read()
    parse_table = GrammarParser.parse_parse_table(INPUT_STRING)
    if __debug__:
        print("{{\n{}\n}}".format(
            ",\n".join([repr(x) for x in parse_table])))

    result = CodeGenerator.generate(parse_table, parser=OUTPUT_PARSER, interfaces=OUTPUT_INTERFACES, implementations=OUTPUT_IMPLEMENTATIONS)
    if result:
        print("Success")
    else:
        print("Success, probably")
