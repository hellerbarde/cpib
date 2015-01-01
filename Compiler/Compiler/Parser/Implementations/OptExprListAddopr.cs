using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListADDOPR : IOptExprList
  {
    public IExpr Expr { get; set; }
  
    public IRepExprList RepExprList { get; set; }
  
    public OptExprListADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
