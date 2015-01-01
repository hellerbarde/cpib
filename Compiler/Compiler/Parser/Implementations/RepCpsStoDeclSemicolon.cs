using System;
using System.Text;

namespace Compiler
{
  public partial class RepCpsStoDeclSEMICOLON : IRepCpsStoDecl
  {
    public Tokennode SEMICOLON { get; set; } 
  
    public IStoDecl stodecl { get; set; }
  
    public IRepCpsStoDecl repcpsstodecl { get; set; }
  
    public RepCpsStoDeclSEMICOLON()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
