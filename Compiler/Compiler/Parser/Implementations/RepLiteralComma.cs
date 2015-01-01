using System;
using System.Text;

namespace Compiler
{
  public partial class RepLiteralCOMMA : IRepLiteral
  {
    public Tokennode COMMA { get; set; } 
  
    public Tokennode LITERAL { get; set; } 
  
    public IRepLiteral repliteral { get; set; }
  
    public RepLiteralCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
