#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Sat Dec 27 17:26:03 2014

@author: Philip Stark
"""


from os import path

# >>> from jinja2 import Template
# >>> template = Template('Hello {{ name }}!')
# >>> template.render(name='John Doe')
from jinja2 import Environment, FileSystemLoader
env = Environment(loader=FileSystemLoader('templates'))


def capitalizefirstchar(string):
    return string[0].capitalize() + string[1:]

env.filters['capitalizefirstchar'] = capitalizefirstchar


def generate(lines, folder):
    """Generate code for the IML Parser.

    :param list lines: List of Line objects representing one line in the parse
                       table
    :param str folder: Path to generate File inside.
    :type lines: list
    :return: Nothing, because of stuff and things.
    """

    generate_parsers(lines)
    for line in lines:
        with open(path.join(folder, 'I{}.cs'.format(capitalizefirstchar(line.name))), 'w+') as ifile:
            generate_interface_file(ifile, line)

        for entry in line.columns:
            with open(path.join(folder, '{}{}.cs'.format(capitalizefirstchar(line.name), entry.name.capitalize())), 'w+') as ifile:
                generate_implementation_file(ifile, line, entry)


def generate_parsers(lines):
    tpl = env.get_template("parser.cs.j2")
    with open("Parser.cs", 'w+') as pfile:
        pfile.write(tpl.render(list_of_nts=lines))


def generate_interface_file(filehandle, line):
    # tpl = Template()
    tpl = env.get_template("interface.cs.j2")
    filehandle.write(tpl.render(line=line))


def generate_implementation_file(filehandle, line, entry):
    # tpl = Template()
    tpl = env.get_template("implementation.cs.j2")
    filehandle.write(tpl.render(line=line, entry=entry))
