using System;
using System.Text;

namespace Compiler
{
  public class CmdWhile : Icmd
  {
    public Token WHILE { get; set; } 
  
    public Token LPAREN { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public Token RPAREN { get; set; } 
  
    public IblockCmd blockCmd { get; set; }
  
    public CmdWhile()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
