using System;
using System.Text;

namespace Compiler
{
  public partial class FunDeclFUN : IFunDecl
  {
    public Tokennode FUN { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IParamList ParamList { get; set; }
  
    public Tokennode RETURNS { get; set; } 
  
    public IStoDecl StoDecl { get; set; }
  
    public IOptGlobImps OptGlobImps { get; set; }
  
    public IOptCpsStoDecl OptCpsStoDecl { get; set; }
  
    public Tokennode DO { get; set; } 
  
    public ICpsCmd CpsCmd { get; set; }
  
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
