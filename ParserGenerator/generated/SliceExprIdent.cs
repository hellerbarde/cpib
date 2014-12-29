using System;
using System.Text;

namespace Compiler
{
  public class SliceExprIdent : IsliceExpr
  {
    public Iexpr expr { get; set; }
  
    public IrepSliceExpr repSliceExpr { get; set; }
  
    public SliceExprIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
