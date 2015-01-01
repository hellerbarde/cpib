using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListIDENT : IOptExprList
  {
    public IExpr Expr { get; set; }
  
    public IRepExprList RepExprList { get; set; }
  
    public OptExprListIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
