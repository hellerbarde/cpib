using System;
using System.Text;

namespace Compiler
{
  public class CpsDeclFun : IcpsDecl
  {
    public Idecl decl { get; set; }
  
    public IrepCpsDecl repCpsDecl { get; set; }
  
    public CpsDeclFun()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
