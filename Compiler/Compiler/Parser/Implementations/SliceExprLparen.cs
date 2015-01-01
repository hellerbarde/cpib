using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprLPAREN : ISliceExpr
  {
    public IExpr Expr { get; set; }
  
    public IRepSliceExpr RepSliceExpr { get; set; }
  
    public SliceExprLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
