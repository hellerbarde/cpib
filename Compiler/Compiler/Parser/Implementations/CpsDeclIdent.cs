using System;
using System.Text;

namespace Compiler
{
  public partial class CpsDeclIDENT : ICpsDecl
  {
    public IDecl Decl { get; set; }
  
    public IRepCpsDecl RepCpsDecl { get; set; }
  
    public CpsDeclIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
