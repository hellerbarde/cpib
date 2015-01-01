using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdNOT : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
