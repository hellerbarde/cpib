using System;
using System.Text;

namespace Compiler
{
  public class Term3Literal : Iterm3
  {
    public Ifactor factor { get; set; }
  
    public IrepTerm4 repTerm4 { get; set; }
  
    public Term3Literal()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
