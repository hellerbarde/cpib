using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdDEBUGIN : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdDEBUGIN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
