using System;
using System.Text;

namespace Compiler
{
  public partial class CmdCALL : ICmd
  {
    public Tokennode CALL { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IExprList exprlist { get; set; }
  
    public IOptGlobInits optglobinits { get; set; }
  
    public CmdCALL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
