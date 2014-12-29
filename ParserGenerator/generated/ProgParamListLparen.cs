using System;
using System.Text;

namespace Compiler
{
  public class ProgParamListLparen : IprogParamList
  {
    public Token LPAREN { get; set; } 
  
    public IprogParams progParams { get; set; }
  
    public Token RPAREN { get; set; } 
  
    public ProgParamListLparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
