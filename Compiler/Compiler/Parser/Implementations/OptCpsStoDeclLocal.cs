using System;
using System.Text;

namespace Compiler
{
  public partial class OptCpsStoDeclLOCAL : IOptCpsStoDecl
  {
    public Tokennode LOCAL { get; set; } 
  
    public ICpsStoDecl cpsstodecl { get; set; }
  
    public OptCpsStoDeclLOCAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
