using System;
using System.Text;

namespace Compiler
{
  public class Term3Ident : Iterm3
  {
    public Ifactor factor { get; set; }
  
    public IrepTerm4 repTerm4 { get; set; }
  
    public Term3Ident()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
