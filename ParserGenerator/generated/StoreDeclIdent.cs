using System;
using System.Text;

namespace Compiler
{
  public class StoreDeclIdent : IstoreDecl
  {
    public IoptModeChange optModeChange { get; set; }
  
    public Itypedident typedident { get; set; }
  
    public StoreDeclIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
