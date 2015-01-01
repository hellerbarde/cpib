using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprNOT : ISliceExpr
  {
    public IExpr expr { get; set; }
  
    public IRepSliceExpr repsliceexpr { get; set; }
  
    public SliceExprNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
