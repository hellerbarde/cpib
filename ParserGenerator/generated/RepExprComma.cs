using System;
using System.Text;

namespace Compiler
{
  public class RepExprComma : IrepExpr
  {
    public Token COMMA { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public IrepExpr repExpr { get; set; }
  
    public RepExprComma()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
