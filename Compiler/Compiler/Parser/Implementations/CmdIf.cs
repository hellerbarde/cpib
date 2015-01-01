using System;
using System.Text;

namespace Compiler
{
  public partial class CmdIF : ICmd
  {
    public Tokennode IF { get; set; } 
  
    public IExpr Expr { get; set; }
  
    public Tokennode THEN { get; set; } 
  
    public ICpsCmd CpsCmd { get; set; }
  
    public Tokennode ELSE { get; set; } 
  
    public ICpsCmd CpsCmd2 { get; set; }
  
    public Tokennode ENDIF { get; set; } 
  
    public CmdIF()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
