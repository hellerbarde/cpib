using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprNOT : ISliceExpr
  {
    public IExpr Expr { get; set; }
  
    public IRepSliceExpr RepSliceExpr { get; set; }
  
    public SliceExprNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
