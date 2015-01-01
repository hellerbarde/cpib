using System;
using System.Text;

namespace Compiler
{
  public partial class CmdWHILE : ICmd
  {
    public Tokennode WHILE { get; set; } 
  
    public IExpr expr { get; set; }
  
    public Tokennode DO { get; set; } 
  
    public ICpsCmd cpscmd { get; set; }
  
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
