using System;
using System.Text;

namespace Compiler
{
  public class GlobInitListIdent : IglobInitList
  {
    public Token IDENT { get; set; } 
  
    public IrepGlobInit repGlobInit { get; set; }
  
    public GlobInitListIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
