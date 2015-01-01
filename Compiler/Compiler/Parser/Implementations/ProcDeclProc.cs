using System;
using System.Text;

namespace Compiler
{
  public partial class ProcDeclPROC : IProcDecl
  {
    public Tokennode PROC { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IParamList ParamList { get; set; }
  
    public IOptGlobImps OptGlobImps { get; set; }
  
    public IOptCpsStoDecl OptCpsStoDecl { get; set; }
  
    public Tokennode DO { get; set; } 
  
    public ICpsCmd CpsCmd { get; set; }
  
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
