using System;
using System.Text;

namespace Compiler
{
  public partial class SliceExprADDOPR : ISliceExpr
  {
    public IExpr expr { get; set; }
  
    public IRepSliceExpr repsliceexpr { get; set; }
  
    public SliceExprADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
