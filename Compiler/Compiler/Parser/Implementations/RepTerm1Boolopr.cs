using System;
using System.Text;

namespace Compiler
{
  public partial class RepTerm1BOOLOPR : IRepTerm1
  {
    public Tokennode BOOLOPR { get; set; } 
  
    public ITerm1 term1 { get; set; }
  
    public IRepTerm1 repterm1 { get; set; }
  
    public RepTerm1BOOLOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
