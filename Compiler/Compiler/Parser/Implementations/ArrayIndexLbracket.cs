using System;
using System.Text;

namespace Compiler
{
  public partial class ArrayIndexLBRACKET : IArrayIndex
  {
    public Tokennode LBRACKET { get; set; } 
  
    public ISliceExpr sliceexpr { get; set; }
  
    public Tokennode RBRACKET { get; set; } 
  
    public IRepArrayIndex reparrayindex { get; set; }
  
    public ArrayIndexLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
