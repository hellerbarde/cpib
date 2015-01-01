using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdNOT : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
