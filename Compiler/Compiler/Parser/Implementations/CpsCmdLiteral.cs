using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdLITERAL : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdLITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
