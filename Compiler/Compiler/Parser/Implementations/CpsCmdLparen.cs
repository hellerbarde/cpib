using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdLPAREN : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
