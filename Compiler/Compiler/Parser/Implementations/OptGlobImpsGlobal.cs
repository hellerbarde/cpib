using System;
using System.Text;

namespace Compiler
{
  public partial class OptGlobImpsGLOBAL : IOptGlobImps
  {
    public Tokennode GLOBAL { get; set; } 
  
    public IGlobImps GlobImps { get; set; }
  
    public OptGlobImpsGLOBAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
