using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprADDOPR : ISliceExpr
  {
    public IExpr Expr { get; set; }
  
    public IRepSliceExpr RepSliceExpr { get; set; }
  
    public SliceExprADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
