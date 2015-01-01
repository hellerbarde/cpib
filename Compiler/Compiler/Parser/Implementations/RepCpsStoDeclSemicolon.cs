using System;
using System.Text;

namespace Compiler
{
  public partial class RepCpsStoDeclSEMICOLON : IRepCpsStoDecl
  {
    public Tokennode SEMICOLON { get; set; } 
  
    public IStoDecl StoDecl { get; set; }
  
    public IRepCpsStoDecl RepCpsStoDecl { get; set; }
  
    public RepCpsStoDeclSEMICOLON()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
