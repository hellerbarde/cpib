using System;
using System.Text;

namespace Compiler
{
  public class RepArrayComma : IrepArray
  {
    public Token COMMA { get; set; } 
  
    public IarrayLiteral arrayLiteral { get; set; }
  
    public IrepArray repArray { get; set; }
  
    public RepArrayComma()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
