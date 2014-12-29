using System;
using System.Text;

namespace Compiler
{
  public class CmdLiteral : Icmd
  {
    public Iexpr expr { get; set; }
  
    public Token BECOMES { get; set; } 
  
    public IoptFill optFill { get; set; }
  
    public Iexpr expr0 { get; set; }
  
    public CmdLiteral()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
