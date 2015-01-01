using System;
using System.Text;

namespace Compiler
{
  public partial class ProgramPROGRAM : IProgram
  {
    public Tokennode PROGRAM { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IProgParamList progparamlist { get; set; }
  
    public IOptCpsDecl optcpsdecl { get; set; }
  
    public Tokennode DO { get; set; } 
  
    public ICpsCmd cpscmd { get; set; }
  
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
