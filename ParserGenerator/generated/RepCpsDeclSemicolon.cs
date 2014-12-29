using System;
using System.Text;

namespace Compiler
{
  public class RepCpsDeclSemicolon : IrepCpsDecl
  {
    public Token SEMICOLON { get; set; } 
  
    public IcpsDecl cpsDecl { get; set; }
  
    public RepCpsDeclSemicolon()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
