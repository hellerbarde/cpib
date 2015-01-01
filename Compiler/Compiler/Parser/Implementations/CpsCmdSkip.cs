using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdSKIP : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdSKIP()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
