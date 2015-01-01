using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdIF : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdIF()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
