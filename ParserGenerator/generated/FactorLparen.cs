using System;
using System.Text;

namespace Compiler
{
  public class FactorLparen : Ifactor
  {
    public Token LPAREN { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public Token RPAREN { get; set; } 
  
    public FactorLparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
