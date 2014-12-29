using System;
using System.Text;

namespace Compiler
{
  public class CpsDeclProc : IcpsDecl
  {
    public Idecl decl { get; set; }
  
    public IrepCpsDecl repCpsDecl { get; set; }
  
    public CpsDeclProc()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
