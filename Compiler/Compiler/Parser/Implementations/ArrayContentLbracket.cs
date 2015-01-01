using System;
using System.Text;

namespace Compiler
{
  public partial class ArrayContentLBRACKET : IArrayContent
  {
    public IArrayLiteral ArrayLiteral { get; set; }
  
    public IRepArray RepArray { get; set; }
  
    public ArrayContentLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
