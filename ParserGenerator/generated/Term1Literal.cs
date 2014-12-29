using System;
using System.Text;

namespace Compiler
{
  public class Term1Literal : Iterm1
  {
    public Iterm2 term2 { get; set; }
  
    public IrepTerm2 repTerm2 { get; set; }
  
    public Term1Literal()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
