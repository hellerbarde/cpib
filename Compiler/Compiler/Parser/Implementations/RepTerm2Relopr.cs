using System;
using System.Text;

namespace Compiler
{
  public partial class RepTerm2RELOPR : IRepTerm2
  {
    public Tokennode RELOPR { get; set; } 
  
    public ITerm2 term2 { get; set; }
  
    public IRepTerm2 repterm2 { get; set; }
  
    public RepTerm2RELOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
