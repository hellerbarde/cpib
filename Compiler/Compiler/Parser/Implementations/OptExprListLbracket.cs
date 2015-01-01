using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListLBRACKET : IOptExprList
  {
    public IExpr Expr { get; set; }
  
    public IRepExprList RepExprList { get; set; }
  
    public OptExprListLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
