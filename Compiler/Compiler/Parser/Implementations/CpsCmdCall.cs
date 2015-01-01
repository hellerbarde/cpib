using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdCALL : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdCALL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
