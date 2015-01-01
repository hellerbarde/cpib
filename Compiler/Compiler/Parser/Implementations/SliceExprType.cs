using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprTYPE : ISliceExpr
  {
    public IExpr expr { get; set; }
  
    public IRepSliceExpr repsliceexpr { get; set; }
  
    public SliceExprTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
