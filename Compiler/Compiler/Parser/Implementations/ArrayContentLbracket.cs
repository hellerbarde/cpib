using System;
using System.Text;

namespace Compiler
{
  public partial class ArrayContentLBRACKET : IArrayContent
  {
    public IArrayLiteral arrayliteral { get; set; }
  
    public IRepArray reparray { get; set; }
  
    public ArrayContentLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
