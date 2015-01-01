using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdIDENT : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
