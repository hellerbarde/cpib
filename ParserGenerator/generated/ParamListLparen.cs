using System;
using System.Text;

namespace Compiler
{
  public class ParamListLparen : IparamList
  {
    public Token LPAREN { get; set; } 
  
    public Iparam param { get; set; }
  
    public Token RPAREN { get; set; } 
  
    public ParamListLparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
