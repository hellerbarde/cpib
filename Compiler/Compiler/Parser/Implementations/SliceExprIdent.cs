using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprIDENT : ISliceExpr
  {
    public IExpr Expr { get; set; }
  
    public IRepSliceExpr RepSliceExpr { get; set; }
  
    public SliceExprIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
