using System;
using System.Text;

namespace Compiler
{
  public class RepCpsStoDeclSemicolon : IrepCpsStoDecl
  {
    public Token SEMICOLON { get; set; } 
  
    public IstoreDecl storeDecl { get; set; }
  
    public IrepCpsStoDecl repCpsStoDecl { get; set; }
  
    public RepCpsStoDeclSemicolon()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
