using System;
using System.Text;

namespace Compiler
{
  public partial class RepTerm3ADDOPR : IRepTerm3
  {
    public Tokennode ADDOPR { get; set; } 
  
    public ITerm3 term3 { get; set; }
  
    public IRepTerm3 repterm3 { get; set; }
  
    public RepTerm3ADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
