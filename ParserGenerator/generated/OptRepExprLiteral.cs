using System;
using System.Text;

namespace Compiler
{
  public class OptRepExprLiteral : IoptRepExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepExpr repExpr { get; set; }
  
    public OptRepExprLiteral()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
