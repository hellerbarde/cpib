using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdLBRACKET : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
