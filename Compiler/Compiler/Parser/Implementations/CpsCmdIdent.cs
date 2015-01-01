using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdIDENT : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
