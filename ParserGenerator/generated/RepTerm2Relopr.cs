using System;
using System.Text;

namespace Compiler
{
  public class RepTerm2Relopr : IrepTerm2
  {
    public Token RELOPR { get; set; } 
  
    public Iterm2 term2 { get; set; }
  
    public IrepTerm2 repTerm2 { get; set; }
  
    public RepTerm2Relopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
