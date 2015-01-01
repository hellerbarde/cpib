using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprLITERAL : ISliceExpr
  {
    public IExpr Expr { get; set; }
  
    public IRepSliceExpr RepSliceExpr { get; set; }
  
    public SliceExprLITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
