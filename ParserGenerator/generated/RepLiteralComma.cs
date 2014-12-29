using System;
using System.Text;

namespace Compiler
{
  public class RepLiteralComma : IrepLiteral
  {
    public Token COMMA { get; set; } 
  
    public Token LITERAL { get; set; } 
  
    public IrepLiteral repLiteral { get; set; }
  
    public RepLiteralComma()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
