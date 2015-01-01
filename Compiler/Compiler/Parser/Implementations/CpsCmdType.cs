using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdTYPE : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
