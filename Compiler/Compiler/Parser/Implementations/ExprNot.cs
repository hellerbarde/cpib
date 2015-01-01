using System;
using System.Text;

namespace Compiler
{
  public partial class ExprNOT : IExpr
  {
    public ITerm1 Term1 { get; set; }
  
    public IRepTerm1 RepTerm1 { get; set; }
  
    public ExprNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
