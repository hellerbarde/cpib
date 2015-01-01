using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprLBRACKET : ISliceExpr
  {
    public IExpr Expr { get; set; }
  
    public IRepSliceExpr RepSliceExpr { get; set; }
  
    public SliceExprLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
