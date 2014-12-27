using System;
using System.Collections;
using System.Collections.Generic;

namespace Compiler
{
  public class Parser
  {
    private IList<Token> TokenList { get; set; }

    private IEnumerator<Token> tokens;
    private Token token;
    private Terminals terminal;

    public Parser(IList<Token> tl)
    {
      TokenList = tl;
      tokens = TokenList.GetEnumerator();
      tokens.Reset();
      tokens.MoveNext();
      token = tokens.Current;
      terminal = token.Terminal;
    }

    private Token consume(Terminals expectedTerminal)
    {
      if (terminal == expectedTerminal) {
        Token consumedToken = token;
        if (terminal != Terminals.SENTINEL) {
          tokens.MoveNext();
          token = tokens.Current;
          // maintain class invariant
          terminal = token.Terminal;
        }
        return consumedToken;
      }
      else {
        throw new GrammarError("terminal expected: " + expectedTerminal +
          ", terminal found: " + terminal);
      }
    }

    public IProgram parseProgram()
    {
      switch (terminal) {
        case Terminals.PROGRAM:
          {
            IProgram program = new Program();
            consume(Terminals.PROGRAM);
            program.Ident = consume(Terminals.IDENT);
            program.ProgParamList = parseProgParamList();
            program.OptGlobCpsDecl = parseOptGlobCpsDecl();
            consume(Terminals.DO);
            program.Cmd = parseCmd();
            program.RepCmd = parseRepCmd();
            consume(Terminals.ENDPROGRAM);
            return program;
          }
        default:
          throw new NotImplementedException();
      }

    }

    public IProgParamList parseProgParamList()
    {
      switch (terminal) {
        case Terminals.LPAREN:
          IProgParamList progParamList = new ProgParamList();
          consume(Terminals.LPAREN);
          progParamList.progParams = parseProgParams();    
          consume(Terminals.RPAREN);
          return progParamList;
        default:
          throw new NotImplementedException();
      }
    }

    public IProgParams parseProgParams()
    {
      switch (terminal) {
        case Terminals.RPAREN:
          {
            var progParams = new ProgParamsEps();
            return progParams;
          }
        case Terminals.FLOWMODE:
          {
            var progParams = new ProgParams();
            progParams.Flowmode = consume(Terminals.FLOWMODE);
            progParams.Changemode = consume(Terminals.CHANGEMODE);
            progParams.TypedIdent = parseTypedIdent();
            progParams.repProgParams = parseRepProgParams();
            return progParams;
          }
        default:
          throw new NotImplementedException();
      }
    }

    public ITypedIdent parseTypedIdent()
    {
      throw new NotImplementedException();
    }

    public IRepProgParams parseRepProgParams()
    {
      throw new NotImplementedException();
    }

    public IOptGlobCpsDecl parseOptGlobCpsDecl()
    {
      switch (terminal) {
        case Terminals.GLOBAL:
          consume(Terminals.GLOBAL);
          IOptGlobCpsDecl ogcd = new OptGlobCpsDecl();
          ogcd.CpsDecl = parseCpsDecl();
          consume(Terminals.DO);
          return ogcd;
        case Terminals.DO:
          return new OptGlobCpsDeclEps();
        default:
          throw new NotImplementedException();
      }
    }

    ICpsDecl parseCpsDecl()
    {
      throw new NotImplementedException();
    }

    ICmd parseCmd()
    {
      switch (terminal) {
        case Terminals.SKIP:
          consume(Terminals.SKIP);
          return new CmdEps();
        default:
          throw new NotImplementedException();
      }
    }

    IRepCmd parseRepCmd()
    {
      if (terminal == Terminals.ENDPROGRAM || terminal == Terminals.ENDFUN || terminal == Terminals.ENDPROC || terminal == Terminals.ENDIF || terminal == Terminals.ENDWHILE) {
        return new RepCmdEps();
      }
      else {
        consume(Terminals.SEMICOLON);
        RepCmd rc = new RepCmd();
        rc.Cmd = parseCmd();
        rc.repCmd = parseRepCmd();
        return rc;
      }
    }

    private class GrammarError : Exception
    {
      public GrammarError(String ErrorMessage) :base (ErrorMessage)
      {

      }
    }
  }
}

