using System;
using System.Text;

namespace Compiler
{
  public class StoreDeclChangemode : IstoreDecl
  {
    public IoptModeChange optModeChange { get; set; }
  
    public Itypedident typedident { get; set; }
  
    public StoreDeclChangemode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
