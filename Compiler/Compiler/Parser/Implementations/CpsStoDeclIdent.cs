using System;
using System.Text;

namespace Compiler
{
  public partial class CpsStoDeclIDENT : ICpsStoDecl
  {
    public IStoDecl StoDecl { get; set; }
  
    public IRepCpsStoDecl RepCpsStoDecl { get; set; }
  
    public CpsStoDeclIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
