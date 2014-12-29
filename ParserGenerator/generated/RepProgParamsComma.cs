using System;
using System.Text;

namespace Compiler
{
  public class RepProgParamsComma : IrepProgParams
  {
    public Token COMMA { get; set; } 
  
    public IprogParams progParams { get; set; }
  
    public RepProgParamsComma()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
