using System;
using System.Text;

namespace Compiler
{
  public partial class ArrayIndexLBRACKET : IArrayIndex
  {
    public Tokennode LBRACKET { get; set; } 
  
    public ISliceExpr SliceExpr { get; set; }
  
    public Tokennode RBRACKET { get; set; } 
  
    public IRepArrayIndex RepArrayIndex { get; set; }
  
    public ArrayIndexLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
