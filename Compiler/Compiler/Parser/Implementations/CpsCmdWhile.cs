using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdWHILE : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdWHILE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
