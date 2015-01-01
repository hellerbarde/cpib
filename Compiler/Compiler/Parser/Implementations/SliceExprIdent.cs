using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprIDENT : ISliceExpr
  {
    public IExpr expr { get; set; }
  
    public IRepSliceExpr repsliceexpr { get; set; }
  
    public SliceExprIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
