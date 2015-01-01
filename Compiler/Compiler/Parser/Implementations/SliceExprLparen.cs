using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprLPAREN : ISliceExpr
  {
    public IExpr expr { get; set; }
  
    public IRepSliceExpr repsliceexpr { get; set; }
  
    public SliceExprLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
