using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdSKIP : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdSKIP()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
