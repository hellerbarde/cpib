using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdLITERAL : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdLITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
