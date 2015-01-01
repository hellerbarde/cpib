using System;
using System.Text;

namespace Compiler
{
  public partial class ExprTYPE : IExpr
  {
    public ITerm1 Term1 { get; set; }
  
    public IRepTerm1 RepTerm1 { get; set; }
  
    public ExprTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
