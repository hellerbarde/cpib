using System;
using System.Text;

namespace Compiler
{
  public class SliceExprAddopr : IsliceExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepSliceExpr repSliceExpr { get; set; }
  
    public SliceExprAddopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
