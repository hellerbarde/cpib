using System;
using System.Text;

namespace Compiler
{
  public class EndBlockEndproc : IendBlock
  {
    public Token ENDPROC { get; set; } 
  
    public EndBlockEndproc()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
