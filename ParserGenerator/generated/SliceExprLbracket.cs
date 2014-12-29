using System;
using System.Text;

namespace Compiler
{
  public class SliceExprLbracket : IsliceExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepSliceExpr repSliceExpr { get; set; }
  
    public SliceExprLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
