using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListLPAREN : IOptExprList
  {
    public IExpr Expr { get; set; }
  
    public IRepExprList RepExprList { get; set; }
  
    public OptExprListLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
