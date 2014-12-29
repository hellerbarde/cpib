using System;
using System.Text;

namespace Compiler
{
  public class Term2Not : Iterm2
  {
    public Iterm3 term3 { get; set; }
  
    public IrepTerm3 repTerm3 { get; set; }
  
    public Term2Not()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
