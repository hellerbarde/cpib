using System;
using System.Text;

namespace Compiler
{
  public partial class CpsStoDeclIDENT : ICpsStoDecl
  {
    public IStoDecl stodecl { get; set; }
  
    public IRepCpsStoDecl repcpsstodecl { get; set; }
  
    public CpsStoDeclIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
