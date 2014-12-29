using System;
using System.Text;

namespace Compiler
{
  public class OptRepExprLbracket : IoptRepExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepExpr repExpr { get; set; }
  
    public OptRepExprLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
