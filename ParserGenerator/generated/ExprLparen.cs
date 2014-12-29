using System;
using System.Text;

namespace Compiler
{
  public class ExprLparen : Iexpr
  {
    public Iterm1 term1 { get; set; }
  
    public IrepTerm1 repTerm1 { get; set; }
  
    public ExprLparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
