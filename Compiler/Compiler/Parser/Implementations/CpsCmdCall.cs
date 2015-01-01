using System;
using System.Text;

namespace Compiler
{
  public partial class CpsCmdCALL : ICpsCmd
  {
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public CpsCmdCALL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
