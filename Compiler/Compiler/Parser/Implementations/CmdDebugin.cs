using System;
using System.Text;

namespace Compiler
{
  public partial class CmdDEBUGIN : ICmd
  {
    public Tokennode DEBUGIN { get; set; } 
  
    public IExpr Expr { get; set; }
  
    public CmdDEBUGIN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
