using System;
using System.Text;

namespace Compiler
{
  public class ExprIdent : Iexpr
  {
    public Iterm1 term1 { get; set; }
  
    public IrepTerm1 repTerm1 { get; set; }
  
    public ExprIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
