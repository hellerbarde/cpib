using System;
using System.Text;

namespace Compiler
{
  public partial class CmdTYPE : ICmd
  {
    public IExpr expr { get; set; }
  
    public Tokennode BECOMES { get; set; } 
  
    public IOptFill optfill { get; set; }
  
    public IExpr expr0 { get; set; }
  
    public CmdTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
