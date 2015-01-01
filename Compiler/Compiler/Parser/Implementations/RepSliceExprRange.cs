using System;
using System.Text;

namespace Compiler
{
  public partial class RepSliceExprRANGE : IRepSliceExpr
  {
    public Tokennode RANGE { get; set; } 
  
    public IExpr Expr { get; set; }
  
    public RepSliceExprRANGE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
