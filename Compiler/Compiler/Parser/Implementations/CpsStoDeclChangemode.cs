using System;
using System.Text;

namespace Compiler
{
  public partial class CpsStoDeclCHANGEMODE : ICpsStoDecl
  {
    public IStoDecl StoDecl { get; set; }
  
    public IRepCpsStoDecl RepCpsStoDecl { get; set; }
  
    public CpsStoDeclCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
