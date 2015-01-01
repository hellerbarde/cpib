using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdADDOPR : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
