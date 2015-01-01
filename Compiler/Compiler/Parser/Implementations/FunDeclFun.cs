using System;
using System.Text;

namespace Compiler
{
  public partial class FunDeclFUN : IFunDecl
  {
    public Tokennode FUN { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IParamList paramlist { get; set; }
  
    public Tokennode RETURNS { get; set; } 
  
    public IStoDecl stodecl { get; set; }
  
    public IOptGlobImps optglobimps { get; set; }
  
    public IOptCpsStoDecl optcpsstodecl { get; set; }
  
    public Tokennode DO { get; set; } 
  
    public ICpsCmd cpscmd { get; set; }
  
    public Tokennode ENDFUN { get; set; } 
  
    public FunDeclFUN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
