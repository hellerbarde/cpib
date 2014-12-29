using System;
using System.Text;

namespace Compiler
{
  public class OptModeChangeChangemode : IoptModeChange
  {
    public Token CHANGEMODE { get; set; } 
  
    public OptModeChangeChangemode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
