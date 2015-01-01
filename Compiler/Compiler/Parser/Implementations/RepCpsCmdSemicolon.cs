using System;
using System.Text;

namespace Compiler
{
  public partial class RepCpsCmdSEMICOLON : IRepCpsCmd
  {
    public Tokennode SEMICOLON { get; set; } 
  
    public ICmd cmd { get; set; }
  
    public IRepCpsCmd repcpscmd { get; set; }
  
    public RepCpsCmdSEMICOLON()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
