using System;
using System.Text;

namespace Compiler
{
  public class Term3Not : Iterm3
  {
    public Ifactor factor { get; set; }
  
    public IrepTerm4 repTerm4 { get; set; }
  
    public Term3Not()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
