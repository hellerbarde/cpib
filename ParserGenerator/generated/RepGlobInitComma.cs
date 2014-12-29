using System;
using System.Text;

namespace Compiler
{
  public class RepGlobInitComma : IrepGlobInit
  {
    public Token COMMA { get; set; } 
  
    public Token IDENT { get; set; } 
  
    public IrepGlobInit repGlobInit { get; set; }
  
    public RepGlobInitComma()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
