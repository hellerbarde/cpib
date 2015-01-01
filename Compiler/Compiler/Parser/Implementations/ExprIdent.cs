using System;
using System.Text;

namespace Compiler
{
  public partial class ExprIDENT : IExpr
  {
    public ITerm1 Term1 { get; set; }
  
    public IRepTerm1 RepTerm1 { get; set; }
  
    public ExprIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
