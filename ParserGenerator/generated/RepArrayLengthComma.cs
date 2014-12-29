using System;
using System.Text;

namespace Compiler
{
  public class RepArrayLengthComma : IrepArrayLength
  {
    public Token COMMA { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public RepArrayLengthComma()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
