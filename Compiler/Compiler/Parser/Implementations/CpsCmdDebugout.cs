using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdDEBUGOUT : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdDEBUGOUT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
