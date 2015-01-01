using System;
using System.Text;

namespace Compiler
{
  public partial class OptCpsDeclGLOBAL : IOptCpsDecl
  {
    public Tokennode GLOBAL { get; set; } 
  
    public ICpsDecl CpsDecl { get; set; }
  
    public OptCpsDeclGLOBAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
