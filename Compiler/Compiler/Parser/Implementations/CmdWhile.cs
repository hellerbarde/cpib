using System;
using System.Text;

namespace Compiler
{
  public partial class CmdWHILE : ICmd
  {
    public Tokennode WHILE { get; set; } 
  
    public IExpr Expr { get; set; }
  
    public Tokennode DO { get; set; } 
  
    public ICpsCmd CpsCmd { get; set; }
  
    public Tokennode ENDWHILE { get; set; } 
  
    public CmdWHILE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
