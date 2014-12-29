using System;
using System.Text;

namespace Compiler
{
  public class ArrayContentLiteral : IarrayContent
  {
    public Token LITERAL { get; set; } 
  
    public IrepLiteral repLiteral { get; set; }
  
    public ArrayContentLiteral()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
