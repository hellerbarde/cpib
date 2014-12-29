using System;
using System.Text;

namespace Compiler
{
  public class EndBlockEndfun : IendBlock
  {
    public Token ENDFUN { get; set; } 
  
    public EndBlockEndfun()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
