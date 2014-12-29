using System;
using System.Text;

namespace Compiler
{
  public class Term2Lparen : Iterm2
  {
    public Iterm3 term3 { get; set; }
  
    public IrepTerm3 repTerm3 { get; set; }
  
    public Term2Lparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
