using System;
using System.Text;

namespace Compiler
{
  public class RepTerm4Multopr : IrepTerm4
  {
    public Token MULTOPR { get; set; } 
  
    public Ifactor factor { get; set; }
  
    public IrepTerm4 repTerm4 { get; set; }
  
    public RepTerm4Multopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
