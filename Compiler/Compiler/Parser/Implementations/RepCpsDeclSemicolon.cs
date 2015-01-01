using System;
using System.Text;

namespace Compiler
{
  public partial class RepCpsDeclSEMICOLON : IRepCpsDecl
  {
    public Tokennode SEMICOLON { get; set; } 
  
    public IDecl decl { get; set; }
  
    public IRepCpsDecl repcpsdecl { get; set; }
  
    public RepCpsDeclSEMICOLON()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
