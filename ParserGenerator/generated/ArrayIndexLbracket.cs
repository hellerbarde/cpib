using System;
using System.Text;

namespace Compiler
{
  public class ArrayIndexLbracket : IarrayIndex
  {
    public Token LBRACKET { get; set; } 
  
    public IsliceExpr sliceExpr { get; set; }
  
    public Token RBRACKET { get; set; } 
  
    public IrepArrayIndex repArrayIndex { get; set; }
  
    public ArrayIndexLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
