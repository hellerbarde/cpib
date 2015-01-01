using System;
using System.Text;

namespace Compiler
{
  public partial class CpsDeclPROC : ICpsDecl
  {
    public IDecl decl { get; set; }
  
    public IRepCpsDecl repcpsdecl { get; set; }
  
    public CpsDeclPROC()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
