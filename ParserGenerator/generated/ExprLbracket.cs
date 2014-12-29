using System;
using System.Text;

namespace Compiler
{
  public class ExprLbracket : Iexpr
  {
    public Iterm1 term1 { get; set; }
  
    public IrepTerm1 repTerm1 { get; set; }
  
    public ExprLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
