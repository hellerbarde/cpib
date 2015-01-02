using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
  public class Scanner
  {
    /// <summary>
    /// Token list, which is the result of the state machine
    /// </summary>
    private IList<Token> TokenList { get; set; }

    /// <summary>
    /// Current State of the state machine
    /// </summary>
    public State CurrentState { get; set; }

    /// <summary>
    /// Definition of all keywords and corresponding tokens
    /// </summary>
    public Dictionary<string, Func<int, Token>> Keywords { get; private set; }

    /// <summary>
    /// Current row the scanner is in (starting by 1)
    /// </summary>
    public int Row { get; private set; }

    /// <summary>
    /// Current column the scanner is in (starting by 1)
    /// </summary>
    public int Col { get; private set; }

    public Scanner()
    {
      #region keywords
      Keywords = new Dictionary<string, Func<int, Token>>();
      Keywords.Add("div", x => new OperatorToken(Terminals.MULTOPR, Operators.DIV));
      Keywords.Add("mod", x => new OperatorToken(Terminals.MULTOPR, Operators.MOD));
      Keywords.Add("bool", x => new TypeToken(Type.BOOL));
      Keywords.Add("int32", x => new TypeToken(Type.INT32));
      Keywords.Add("decimal", x => new TypeToken(Type.DECIMAL));
      Keywords.Add("call", x => new Token(Terminals.CALL));
      Keywords.Add("const", x => new ChangeModeToken(ChangeMode.CONST));
      Keywords.Add("var", x => new ChangeModeToken(ChangeMode.VAR));
      Keywords.Add("copy", x => new MechModeToken(MechMode.COPY));
      Keywords.Add("ref", x => new MechModeToken(MechMode.REF));
      Keywords.Add("debugin", x => new Token(Terminals.DEBUGIN));
      Keywords.Add("debugout", x => new Token(Terminals.DEBUGOUT));
      Keywords.Add("do", x => new Token(Terminals.DO));
      Keywords.Add("else", x => new Token(Terminals.ELSE));
      Keywords.Add("endfun", x => new Token(Terminals.ENDFUN));
      Keywords.Add("endif", x => new Token(Terminals.ENDIF));
      Keywords.Add("endproc", x => new Token(Terminals.ENDPROC));
      Keywords.Add("endprogram", x => new Token(Terminals.ENDPROGRAM));
      Keywords.Add("endwhile", x => new Token(Terminals.ENDWHILE));
      Keywords.Add("fun", x => new Token(Terminals.FUN)); //so funny
      Keywords.Add("global", x => new Token(Terminals.GLOBAL));
      Keywords.Add("if", x => new Token(Terminals.IF));
      Keywords.Add("in", x => new FlowModeToken(FlowMode.IN));
      Keywords.Add("inout", x => new FlowModeToken(FlowMode.INOUT));
      Keywords.Add("out", x => new FlowModeToken(FlowMode.OUT));
      Keywords.Add("init", x => new Token(Terminals.INIT));
      Keywords.Add("local", x => new Token(Terminals.LOCAL));
      Keywords.Add("not", x => new Token(Terminals.NOT));
      Keywords.Add("proc", x => new Token(Terminals.PROC));
      Keywords.Add("program", x => new Token(Terminals.PROGRAM));
      Keywords.Add("returns", x => new Token(Terminals.RETURNS));
      Keywords.Add("skip", x => new Token(Terminals.SKIP));
      Keywords.Add("then", x => new Token(Terminals.THEN));
      Keywords.Add("while", x => new Token(Terminals.WHILE));
      Keywords.Add("..", x => new Token(Terminals.RANGE));
      Keywords.Add("array", x => new Token(Terminals.ARRAY));
      Keywords.Add("fill", x => new Token(Terminals.FILL));
      #endregion
    }

    /// <summary>
    /// Runs a state machine to execute the lexical analysis
    /// </summary>
    /// <param name="reader">IML source code input</param>
    /// <returns>Token list as result of the lexical analysis</returns>
    public IList<Token> Scan(StreamReader reader)
    {
      lock (this) {
        TokenList = new List<Token>();
        try {
          CurrentState = new DefaultState();
          Row = 0;
          while (!reader.EndOfStream) {
            ++Row;
            Col = 0;
            string line = reader.ReadLine();
            foreach (char c in line) {
              ++Col;
              CurrentState.Handle(this, c);
            }
            CurrentState.Handle(this, '\n'); //newline char is omitted in the ReadLine method
          }
          CurrentState.Handle(this, ' '); //More user friendly than to require a new line at the end of the file
          if (!(CurrentState is DefaultState)) {
            throw new LexicalException("Unexpected EOF (end of file)");
          }
        } catch (LexicalException ex) {
          throw new LexicalException(String.Format("Row: {0} Col: {1} Msg: {2}", Row, Col, ex.Message));
        } finally {
          reader.Close();
        }
        return TokenList;
      }
    }

    /// <summary>
    /// Add given Token to the token list
    /// </summary>
    /// <param name="token">Token to append to the token list</param>
    public void AddToken(Token token)
    {
      token.Row = Row;
      token.Column = Col;
      TokenList.Add(token);
    }
  }
}
