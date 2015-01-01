using System;
using System.Text;

namespace Compiler
{
  public partial class ProcDeclPROC : IProcDecl
  {
    public Tokennode PROC { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IParamList paramlist { get; set; }
  
    public IOptGlobImps optglobimps { get; set; }
  
    public IOptCpsStoDecl optcpsstodecl { get; set; }
  
    public Tokennode DO { get; set; } 
  
    public ICpsCmd cpscmd { get; set; }
  
    public Tokennode ENDPROC { get; set; } 
  
    public ProcDeclPROC()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
