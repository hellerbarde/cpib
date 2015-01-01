using System;
using System.Text;

namespace Compiler
{
  public partial class RepCpsDeclSEMICOLON : IRepCpsDecl
  {
    public Tokennode SEMICOLON { get; set; } 
  
    public IDecl Decl { get; set; }
  
    public IRepCpsDecl RepCpsDecl { get; set; }
  
    public RepCpsDeclSEMICOLON()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
