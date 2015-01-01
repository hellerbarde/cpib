using System;
using System.Text;

namespace Compiler
{
  public partial class RepArrayCOMMA : IRepArray
  {
    public Tokennode COMMA { get; set; } 
  
    public IArrayLiteral arrayliteral { get; set; }
  
    public IRepArray reparray { get; set; }
  
    public RepArrayCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
