using System;
using System.Text;

namespace Compiler
{
  public class Term1Addopr : Iterm1
  {
    public Iterm2 term2 { get; set; }
  
    public IrepTerm2 repTerm2 { get; set; }
  
    public Term1Addopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
