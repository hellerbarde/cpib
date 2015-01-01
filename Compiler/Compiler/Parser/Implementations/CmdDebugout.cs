using System;
using System.Text;

namespace Compiler
{
  public partial class CmdDEBUGOUT : ICmd
  {
    public Tokennode DEBUGOUT { get; set; } 
  
    public IExpr expr { get; set; }
  
    public CmdDEBUGOUT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
