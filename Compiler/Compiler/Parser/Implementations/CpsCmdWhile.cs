using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdWHILE : ICpsCmd
  {
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public CpsCmdWHILE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
