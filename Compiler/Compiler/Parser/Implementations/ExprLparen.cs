using System;
using System.Text;

namespace Compiler
{
  public partial class ExprLPAREN : IExpr
  {
    public ITerm1 term1 { get; set; }
  
    public IRepTerm1 repterm1 { get; set; }
  
    public ExprLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
