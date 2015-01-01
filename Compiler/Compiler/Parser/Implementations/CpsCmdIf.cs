using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdIF : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdIF()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
