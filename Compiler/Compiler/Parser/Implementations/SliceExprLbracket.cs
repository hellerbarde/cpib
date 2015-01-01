using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprLBRACKET : ISliceExpr
  {
    public IExpr expr { get; set; }
  
    public IRepSliceExpr repsliceexpr { get; set; }
  
    public SliceExprLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
