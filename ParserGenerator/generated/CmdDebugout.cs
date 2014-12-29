using System;
using System.Text;

namespace Compiler
{
  public class CmdDebugout : Icmd
  {
    public Token DEBUGOUT { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public CmdDebugout()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
