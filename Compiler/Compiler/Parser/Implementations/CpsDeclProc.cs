using System;
using System.Text;

namespace Compiler
{
  public partial class CpsDeclPROC : ICpsDecl
  {
    public IDecl Decl { get; set; }
  
    public IRepCpsDecl RepCpsDecl { get; set; }
  
    public CpsDeclPROC()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
