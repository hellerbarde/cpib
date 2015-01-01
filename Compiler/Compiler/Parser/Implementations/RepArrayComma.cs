using System;
using System.Text;

namespace Compiler
{
  public partial class RepArrayCOMMA : IRepArray
  {
    public Tokennode COMMA { get; set; } 
  
    public IArrayLiteral ArrayLiteral { get; set; }
  
    public IRepArray RepArray { get; set; }
  
    public RepArrayCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
