using System;
using System.Text;

namespace Compiler
{
  public class RepParamComma : IrepParam
  {
    public Token COMMA { get; set; } 
  
    public Iparam param { get; set; }
  
    public RepParamComma()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
