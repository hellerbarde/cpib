using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprLITERAL : ISliceExpr
  {
    public IExpr expr { get; set; }
  
    public IRepSliceExpr repsliceexpr { get; set; }
  
    public SliceExprLITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
