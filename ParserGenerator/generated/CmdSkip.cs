using System;
using System.Text;

namespace Compiler
{
  public class CmdSkip : Icmd
  {
    public Token SKIP { get; set; } 
  
    public CmdSkip()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
