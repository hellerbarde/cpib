using System;
using System.Text;

namespace Compiler
{
  public class OptRepExprNot : IoptRepExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepExpr repExpr { get; set; }
  
    public OptRepExprNot()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
