using System;
using System.Text;

namespace Compiler
{
  public class ExprListLparen : IexprList
  {
    public Token LPAREN { get; set; } 
  
    public IoptRepExpr optRepExpr { get; set; }
  
    public Token RPAREN { get; set; } 
  
    public ExprListLparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
