using System;
using System.Text;

namespace Compiler
{
  public class FactorLbracket : Ifactor
  {
    public IarrayLiteral arrayLiteral { get; set; }
  
    public FactorLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
