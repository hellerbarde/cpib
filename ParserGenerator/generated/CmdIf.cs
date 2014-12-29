using System;
using System.Text;

namespace Compiler
{
  public class CmdIf : Icmd
  {
    public Token IF { get; set; } 
  
    public Token LPAREN { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public Token RPAREN { get; set; } 
  
    public IblockCmd blockCmd { get; set; }
  
    public Token ELSE { get; set; } 
  
    public IblockCmd blockCmd0 { get; set; }
  
    public CmdIf()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
