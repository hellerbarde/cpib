using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListNOT : IOptExprList
  {
    public IExpr Expr { get; set; }
  
    public IRepExprList RepExprList { get; set; }
  
    public OptExprListNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
