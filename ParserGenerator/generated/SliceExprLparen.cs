using System;
using System.Text;

namespace Compiler
{
  public class SliceExprLparen : IsliceExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepSliceExpr repSliceExpr { get; set; }
  
    public SliceExprLparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
