using System;
using System.Text;

namespace Compiler
{
  public class RepCmdSemicolon : IrepCmd
  {
    public Token SEMICOLON { get; set; } 
  
    public Icmd cmd { get; set; }
  
    public IrepCmd repCmd { get; set; }
  
    public RepCmdSemicolon()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
