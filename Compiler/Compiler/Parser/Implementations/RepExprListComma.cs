using System;
using System.Text;

namespace Compiler
{
  public partial class RepExprListCOMMA : IRepExprList
  {
    public Tokennode COMMA { get; set; } 
  
    public IExpr Expr { get; set; }
  
    public IRepExprList RepExprList { get; set; }
  
    public RepExprListCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
