using System;
using System.Text;

namespace Compiler
{
  public class RepTerm3Addopr : IrepTerm3
  {
    public Token ADDOPR { get; set; } 
  
    public Iterm3 term3 { get; set; }
  
    public IrepTerm3 repTerm3 { get; set; }
  
    public RepTerm3Addopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
