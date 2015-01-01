using System;
using System.Text;

namespace Compiler
{
  public partial class ExprNOT : IExpr
  {
    public ITerm1 term1 { get; set; }
  
    public IRepTerm1 repterm1 { get; set; }
  
    public ExprNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
