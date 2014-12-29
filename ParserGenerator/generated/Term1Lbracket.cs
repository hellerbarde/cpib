using System;
using System.Text;

namespace Compiler
{
  public class Term1Lbracket : Iterm1
  {
    public Iterm2 term2 { get; set; }
  
    public IrepTerm2 repTerm2 { get; set; }
  
    public Term1Lbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
