using System;
using System.Text;

namespace Compiler
{
  public partial class CmdSKIP : ICmd
  {
    public Tokennode SKIP { get; set; } 
  
    public CmdSKIP()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
