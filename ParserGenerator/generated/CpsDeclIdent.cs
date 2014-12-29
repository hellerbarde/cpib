using System;
using System.Text;

namespace Compiler
{
  public class CpsDeclIdent : IcpsDecl
  {
    public Idecl decl { get; set; }
  
    public IrepCpsDecl repCpsDecl { get; set; }
  
    public CpsDeclIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
