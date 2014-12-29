using System;
using System.Text;

namespace Compiler
{
  public class ExprAddopr : Iexpr
  {
    public Iterm1 term1 { get; set; }
  
    public IrepTerm1 repTerm1 { get; set; }
  
    public ExprAddopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
