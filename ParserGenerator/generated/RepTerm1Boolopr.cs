using System;
using System.Text;

namespace Compiler
{
  public class RepTerm1Boolopr : IrepTerm1
  {
    public Token BOOLOPR { get; set; } 
  
    public Iterm1 term1 { get; set; }
  
    public IrepTerm1 repTerm1 { get; set; }
  
    public RepTerm1Boolopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
