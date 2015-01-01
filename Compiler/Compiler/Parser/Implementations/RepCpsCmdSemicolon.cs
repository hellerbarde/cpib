using System;
using System.Text;

namespace Compiler
{
  public partial class RepCpsCmdSEMICOLON : IRepCpsCmd
  {
    public Tokennode SEMICOLON { get; set; } 
  
    public ICmd Cmd { get; set; }
  
    public IRepCpsCmd RepCpsCmd { get; set; }
  
    public RepCpsCmdSEMICOLON()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
