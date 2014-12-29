using System;
using System.Text;

namespace Compiler
{
  public class CmdCall : Icmd
  {
    public Token CALL { get; set; } 
  
    public Token IDENT { get; set; } 
  
    public IexprList exprList { get; set; }
  
    public Token INIT { get; set; } 
  
    public IglobInitList globInitList { get; set; }
  
    public CmdCall()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
