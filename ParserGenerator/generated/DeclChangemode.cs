using System;
using System.Text;

namespace Compiler
{
  public class DeclChangemode : Idecl
  {
    public IstoreDecl storeDecl { get; set; }
  
    public DeclChangemode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
