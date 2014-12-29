using System;
using System.Text;

namespace Compiler
{
  public class FactorLiteral : Ifactor
  {
    public Token LITERAL { get; set; } 
  
    public FactorLiteral()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
