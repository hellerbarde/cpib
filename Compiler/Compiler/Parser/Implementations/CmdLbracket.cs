using System;
using System.Text;

namespace Compiler
{
  public partial class CmdLBRACKET : ICmd
  {
    public IExpr Expr { get; set; }
  
    public Tokennode BECOMES { get; set; } 
  
    public IOptFill OptFill { get; set; }
  
    public IExpr Expr2 { get; set; }
  
    public CmdLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
