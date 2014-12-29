using System;
using System.Text;

namespace Compiler
{
  public class Term3Addopr : Iterm3
  {
    public Ifactor factor { get; set; }
  
    public IrepTerm4 repTerm4 { get; set; }
  
    public Term3Addopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
