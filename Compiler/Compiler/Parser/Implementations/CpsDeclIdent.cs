using System;
using System.Text;

namespace Compiler
{
  public partial class CpsDeclIDENT : ICpsDecl
  {
    public IDecl decl { get; set; }
  
    public IRepCpsDecl repcpsdecl { get; set; }
  
    public CpsDeclIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
