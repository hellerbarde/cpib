using System;
using System.Text;

namespace Compiler
{
  public partial class OptInitOrExprListOrArrayAccessLBRACKET : IOptInitOrExprListOrArrayAccess
  {
    public IArrayIndex ArrayIndex { get; set; }
  
    public OptInitOrExprListOrArrayAccessLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
