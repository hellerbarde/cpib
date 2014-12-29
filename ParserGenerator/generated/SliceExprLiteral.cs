using System;
using System.Text;

namespace Compiler
{
  public class SliceExprLiteral : IsliceExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepSliceExpr repSliceExpr { get; set; }
  
    public SliceExprLiteral()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
