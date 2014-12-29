using System;
using System.Text;

namespace Compiler
{
  public class OptRepExprLparen : IoptRepExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepExpr repExpr { get; set; }
  
    public OptRepExprLparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
