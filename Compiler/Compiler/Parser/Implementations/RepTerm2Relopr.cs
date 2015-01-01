using System;
using System.Text;

namespace Compiler
{
  public partial class RepTerm2RELOPR : IRepTerm2
  {
    public Tokennode RELOPR { get; set; } 
  
    public ITerm2 Term2 { get; set; }
  
    public IRepTerm2 RepTerm2 { get; set; }
  
    public RepTerm2RELOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
