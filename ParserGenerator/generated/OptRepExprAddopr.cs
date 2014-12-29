using System;
using System.Text;

namespace Compiler
{
  public class OptRepExprAddopr : IoptRepExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepExpr repExpr { get; set; }
  
    public OptRepExprAddopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
