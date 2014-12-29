using System;
using System.Text;

namespace Compiler
{
  public class CpsDeclChangemode : IcpsDecl
  {
    public Idecl decl { get; set; }
  
    public IrepCpsDecl repCpsDecl { get; set; }
  
    public CpsDeclChangemode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
