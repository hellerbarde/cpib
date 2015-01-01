using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdDEBUGOUT : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdDEBUGOUT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
