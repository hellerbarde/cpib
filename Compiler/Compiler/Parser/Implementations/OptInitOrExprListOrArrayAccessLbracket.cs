using System;
using System.Text;

namespace Compiler
{
  public partial class OptInitOrExprListOrArrayAccessLBRACKET : IOptInitOrExprListOrArrayAccess
  {
    public IArrayIndex arrayindex { get; set; }
  
    public OptInitOrExprListOrArrayAccessLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
