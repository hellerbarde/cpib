using System;
using System.Text;

namespace Compiler
{
  public partial class CmdIF : ICmd
  {
    public Tokennode IF { get; set; } 
  
    public IExpr expr { get; set; }
  
    public Tokennode THEN { get; set; } 
  
    public ICpsCmd cpscmd { get; set; }
  
    public Tokennode ELSE { get; set; } 
  
    public ICpsCmd cpscmd0 { get; set; }
  
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
