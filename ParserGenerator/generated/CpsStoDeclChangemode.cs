using System;
using System.Text;

namespace Compiler
{
  public class CpsStoDeclChangemode : IcpsStoDecl
  {
    public IstoreDecl storeDecl { get; set; }
  
    public IrepCpsStoDecl repCpsStoDecl { get; set; }
  
    public CpsStoDeclChangemode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
