using System;
using System.Text;

namespace Compiler
{
  public class RepSliceExprDotdot : IrepSliceExpr
  {
    public Token DOTDOT { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public RepSliceExprDotdot()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
