using System;
using System.Text;

namespace Compiler
{
  public class CmdIdent : Icmd
  {
    public Iexpr expr { get; set; }
  
    public Token BECOMES { get; set; } 
  
    public IoptFill optFill { get; set; }
  
    public Iexpr expr0 { get; set; }
  
    public CmdIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
