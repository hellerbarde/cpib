using System;
using System.Text;

namespace Compiler
{
  public class CpsStoDeclIdent : IcpsStoDecl
  {
    public IstoreDecl storeDecl { get; set; }
  
    public IrepCpsStoDecl repCpsStoDecl { get; set; }
  
    public CpsStoDeclIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
