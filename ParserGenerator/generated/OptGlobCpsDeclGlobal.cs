using System;
using System.Text;

namespace Compiler
{
  public class OptGlobCpsDeclGlobal : IoptGlobCpsDecl
  {
    public Token GLOBAL { get; set; } 
  
    public IcpsDecl cpsDecl { get; set; }
  
    public OptGlobCpsDeclGlobal()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
