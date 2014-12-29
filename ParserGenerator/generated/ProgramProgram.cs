using System;
using System.Text;

namespace Compiler
{
  public class ProgramProgram : Iprogram
  {
    public Token PROGRAM { get; set; } 
  
    public Token IDENT { get; set; } 
  
    public IprogParamList progParamList { get; set; }
  
    public IoptGlobCpsDecl optGlobCpsDecl { get; set; }
  
    public Token DO { get; set; } 
  
    public Icmd cmd { get; set; }
  
    public IrepCmd repCmd { get; set; }
  
    public Token ENDPROGRAM { get; set; } 
  
    public ProgramProgram()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
