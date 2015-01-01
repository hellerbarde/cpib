using System;
using System.Text;

namespace Compiler
{
  public partial class ProgramPROGRAM : IProgram
  {
    public Tokennode PROGRAM { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IProgParamList ProgParamList { get; set; }
  
    public IOptCpsDecl OptCpsDecl { get; set; }
  
    public Tokennode DO { get; set; } 
  
    public ICpsCmd CpsCmd { get; set; }
  
    public Tokennode ENDPROGRAM { get; set; } 
  
    public ProgramPROGRAM()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
