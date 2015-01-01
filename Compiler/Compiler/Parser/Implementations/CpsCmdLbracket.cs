using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdLBRACKET : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
