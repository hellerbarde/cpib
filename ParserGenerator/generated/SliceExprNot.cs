using System;
using System.Text;

namespace Compiler
{
  public class SliceExprNot : IsliceExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepSliceExpr repSliceExpr { get; set; }
  
    public SliceExprNot()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
