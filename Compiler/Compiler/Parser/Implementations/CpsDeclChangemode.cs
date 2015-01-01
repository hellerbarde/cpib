using System;
using System.Text;

namespace Compiler
{
  public partial class CpsDeclCHANGEMODE : ICpsDecl
  {
    public IDecl decl { get; set; }
  
    public IRepCpsDecl repcpsdecl { get; set; }
  
    public CpsDeclCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
