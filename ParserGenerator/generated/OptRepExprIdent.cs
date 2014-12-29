using System;
using System.Text;

namespace Compiler
{
  public class OptRepExprIdent : IoptRepExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepExpr repExpr { get; set; }
  
    public OptRepExprIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
