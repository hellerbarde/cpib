using System;
using System.Text;

namespace Compiler
{
  public partial class RepArrayIndexLBRACKET : IRepArrayIndex
  {
    public IArrayIndex ArrayIndex { get; set; }
  
    public RepArrayIndexLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
