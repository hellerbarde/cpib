using System;
using System.Text;

namespace Compiler
{
  public class EndBlockEndwhile : IendBlock
  {
    public Token ENDWHILE { get; set; } 
  
    public EndBlockEndwhile()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
