using System;
using System.Text;

namespace Compiler
{
  public class EndBlockEndif : IendBlock
  {
    public Token ENDIF { get; set; } 
  
    public EndBlockEndif()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
