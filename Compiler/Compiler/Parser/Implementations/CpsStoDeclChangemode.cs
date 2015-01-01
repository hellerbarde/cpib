using System;
using System.Text;

namespace Compiler
{
  public partial class CpsStoDeclCHANGEMODE : ICpsStoDecl
  {
    public IStoDecl stodecl { get; set; }
  
    public IRepCpsStoDecl repcpsstodecl { get; set; }
  
    public CpsStoDeclCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
