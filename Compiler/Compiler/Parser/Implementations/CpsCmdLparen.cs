using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdLPAREN : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
