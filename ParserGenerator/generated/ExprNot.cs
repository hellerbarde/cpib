using System;
using System.Text;

namespace Compiler
{
  public class ExprNot : Iexpr
  {
    public Iterm1 term1 { get; set; }
  
    public IrepTerm1 repTerm1 { get; set; }
  
    public ExprNot()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
