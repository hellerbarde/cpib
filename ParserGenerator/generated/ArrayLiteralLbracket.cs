using System;
using System.Text;

namespace Compiler
{
  public class ArrayLiteralLbracket : IarrayLiteral
  {
    public Token LBRACKET { get; set; } 
  
    public IarrayContent arrayContent { get; set; }
  
    public Token RBRACKET { get; set; } 
  
    public ArrayLiteralLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
