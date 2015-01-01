using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdDEBUGIN : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdDEBUGIN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
