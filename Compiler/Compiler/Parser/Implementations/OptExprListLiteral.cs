using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListLITERAL : IOptExprList
  {
    public IExpr Expr { get; set; }
  
    public IRepExprList RepExprList { get; set; }
  
    public OptExprListLITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
