#!/usr/bin/env python3
# coding: utf-8

from collections import defaultdict


def get_indentation(s):
    for (n, c) in enumerate(s):
        if not c == " ":
            return n
    return None


def parse_nonterminal(s):
    return s[1:-1]


def is_nonterminal(s):
    return s[0] == "<" and s[-1] == ">"


def parse_terminal(s):
    return s.split()[1]


# def parse_entry_list(s):
#     def convert_to_object(s):
#         return NonterminalEntry(parse_nonterminal(s)) \
#             if is_nonterminal(s) \
#             else TerminalEntry(s)
#     return [convert_to_object(entry) for entry in s.split()]


def parse_entry_list(string):
    """parse the line of tokens representing the entry
    :param string: line of tokens to parse
    :type string: str
    """
    list_of_tokens = defaultdict(int)
    result = []
    name = str()
    tokentype = str()
    token = str()
    for part in string.split():
        if is_nonterminal(part):
            tokentype = parse_nonterminal(part)
        else:
            tokentype = part
        list_of_tokens[tokentype] += 1
        if list_of_tokens[tokentype] > 1:
            name = tokentype + str(list_of_tokens[token])
        else:
            name = tokentype
        result.append(NonterminalEntry(parse_nonterminal(name), tokentype)
                      if is_nonterminal(part)
                      else TerminalEntry(name, tokentype))
    return result


class Line(object):
    name = None
    columns = None

    def __init__(self, name):
        self.name = name
        self.columns = []

    def __repr__(self):
        return "\"{name}\": {{{value}}}".format(
            name=self.name,
            value=",".join([repr(x) for x in self.columns])
        )


class Column(object):
    name = None
    entry = None

    def __init__(self, name):
        self.name = name
        self.entry = []

    def __repr__(self):
        return "\"{name}\": {value}".format(
            name=self.name,
            value=repr(self.entry))

    def set_entry(self, e):
        self.entry = e


class Entry(object):
    name = None
    tokentype = None

    def __init__(self, name, tokentype):
        self.name = name
        self.tokentype = tokentype

    def __repr__(self):
        raise NotImplementedError()


class TerminalEntry(Entry):
    type = None

    def __init__(self, name, tokentype):
        super().__init__(name, tokentype)
        # for ease of use during templating
        self.type = "Terminal"

    def __repr__(self):
        return "\"T(" + self.tokentype + ")\""


class NonterminalEntry(Entry):
    type = None

    def __init__(self, name, tokentype):
        super().__init__(name, tokentype)
        # for ease of use during templating
        self.type = "Nonterminal"

    def __repr__(self):
        return "\"N(" + self.tokentype + ")\""


class Epsilon(Entry):

    def __init__(self):
        super().__init__(None, None)

    def __repr__(self):
        return "\"Eps()\""

# sort of...
# SCHEMA = {
#   "line1" : {
#     "column1": ["entry1", "entry2", "entry3"],
#     "column2": ["entry4", "entry2", "entry3"]
#   }
# }


def parse_parse_table(grammar):
    result = []
    state = "notentry"
    current_line = None
    current_column = None

    for l in grammar.split("\n"):
        if state == "notentry" and get_indentation(l) == 0:
            if not is_nonterminal(l):
                print("Grammar: error")

            # for clarity
            state = "notentry"

            current_line = Line(parse_nonterminal(l))
            # current_line = parse_nonterminal(l)
            result.append(current_line)

        elif state == "notentry" and get_indentation(l) == 2:
            current_column = Column(parse_terminal(l))
            # current_column = parse_terminal(l)
            current_line.columns.append(current_column)
            state = "entry"

        elif state == "entry":
            if not get_indentation(l):
                # This is empty (Epsilon)
                current_column.set_entry([Epsilon()])
            else:
                # There is an entry with at least one symbol.
                symbols = parse_entry_list(l)
                current_column.set_entry(symbols)
            state = "notentry"

    return result


if __name__ == '__main__':
    EXAMPLE_GRAMMAR = """<optModeFlow>
  terminal IDENT

  terminal CHANGEMODE

  terminal MECHMODE

  terminal FLOWMODE
    FLOWMODE
<cpsDecl>
  terminal DO

  terminal PROC
    <decl> <repCpsDecl>
  terminal FUN
    <decl> <repCpsDecl>
  terminal IDENT
    <decl> <repCpsDecl>
  terminal CHANGEMODE
    <decl> <repCpsDecl>
<repCpsDecl>
  terminal DO

  terminal SEMICOLON
    SEMICOLON <cpsDecl>"""

    print("{{\n{}\n}}".format(
        ",\n".join([repr(x) for x in parse_parse_table(EXAMPLE_GRAMMAR)])))
