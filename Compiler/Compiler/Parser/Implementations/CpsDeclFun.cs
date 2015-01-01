using System;
using System.Text;

namespace Compiler
{
  public partial class CpsDeclFUN : ICpsDecl
  {
    public IDecl decl { get; set; }
  
    public IRepCpsDecl repcpsdecl { get; set; }
  
    public CpsDeclFUN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
