using System;
using System.Text;

namespace Compiler
{
  public partial class CpsDeclFUN : ICpsDecl
  {
    public IDecl Decl { get; set; }
  
    public IRepCpsDecl RepCpsDecl { get; set; }
  
    public CpsDeclFUN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
