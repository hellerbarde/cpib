using System;
using System.Text;

namespace Compiler
{
  public partial class ArrayLiteralLBRACKET : IArrayLiteral
  {
    public Tokennode LBRACKET { get; set; } 
  
    public IArrayContent ArrayContent { get; set; }
  
    public Tokennode RBRACKET { get; set; } 
  
    public ArrayLiteralLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
