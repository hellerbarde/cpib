using System;
using System.Collections;
using System.Collections.Generic;

namespace Compiler
{
  public class Parser
  {
    private IList<Token> TokenList { get; set; }

    private IEnumerator<Token> walker;
    private Token token;
    private Terminals terminal;

    public Parser(IList<Token> tl)
    {
      TokenList = tl;
      walker = TokenList.GetEnumerator();
      walker.Reset();
      walker.MoveNext();
      token = walker.Current;
      terminal = token.Terminal;
    }

    private Token consume(Terminals expectedTerminal)
    {
      if (terminal == expectedTerminal) {
        Token consumedToken = token;
        if (terminal != Terminals.SENTINEL) {
          walker.MoveNext();
          token = walker.Current;
          // maintain class invariant
          terminal = token.Terminal;
        }
        return consumedToken;
      }
      else
      {
        throw new GrammarError("terminal expected: " + expectedTerminal +
                               ", terminal found: " + terminal);
      }
    }

    public void parse()
    {
      consume(Terminals.PROGRAM);       
    }

    private class GrammarError : Exception
    {
      public GrammarError(String errorMessage)
      {

      }
    }
  }
}

