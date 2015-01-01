using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdTYPE : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
