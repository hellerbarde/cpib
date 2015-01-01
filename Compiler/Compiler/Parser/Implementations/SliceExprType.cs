using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprTYPE : ISliceExpr
  {
    public IExpr Expr { get; set; }
  
    public IRepSliceExpr RepSliceExpr { get; set; }
  
    public SliceExprTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
