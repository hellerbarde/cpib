using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListTYPE : IOptExprList
  {
    public IExpr Expr { get; set; }
  
    public IRepExprList RepExprList { get; set; }
  
    public OptExprListTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
