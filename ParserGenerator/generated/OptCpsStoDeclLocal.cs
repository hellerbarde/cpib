using System;
using System.Text;

namespace Compiler
{
  public class OptCpsStoDeclLocal : IoptCpsStoDecl
  {
    public Token LOCAL { get; set; } 
  
    public IcpsStoDecl cpsStoDecl { get; set; }
  
    public OptCpsStoDeclLocal()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
