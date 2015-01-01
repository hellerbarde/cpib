using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdADDOPR : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
