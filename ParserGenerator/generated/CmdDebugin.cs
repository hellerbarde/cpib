using System;
using System.Text;

namespace Compiler
{
  public class CmdDebugin : Icmd
  {
    public Token DEBUGIN { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public CmdDebugin()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
