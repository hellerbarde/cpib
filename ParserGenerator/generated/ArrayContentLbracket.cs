using System;
using System.Text;

namespace Compiler
{
  public class ArrayContentLbracket : IarrayContent
  {
    public IarrayLiteral arrayLiteral { get; set; }
  
    public IrepArray repArray { get; set; }
  
    public ArrayContentLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
