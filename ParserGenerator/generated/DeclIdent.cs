using System;
using System.Text;

namespace Compiler
{
  public class DeclIdent : Idecl
  {
    public IstoreDecl storeDecl { get; set; }
  
    public DeclIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
