using System;
using System.Text;

namespace Compiler
{
  public class ExprLiteral : Iexpr
  {
    public Iterm1 term1 { get; set; }
  
    public IrepTerm1 repTerm1 { get; set; }
  
    public ExprLiteral()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
