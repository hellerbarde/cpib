using System;
using System.Text;

namespace Compiler
{
  public partial class CpsDeclCHANGEMODE : ICpsDecl
  {
    public IDecl Decl { get; set; }
  
    public IRepCpsDecl RepCpsDecl { get; set; }
  
    public CpsDeclCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
