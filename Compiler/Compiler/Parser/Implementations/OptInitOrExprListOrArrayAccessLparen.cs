using System;
using System.Text;

namespace Compiler
{
  public partial class OptInitOrExprListOrArrayAccessLPAREN : IOptInitOrExprListOrArrayAccess
  {
    public IExprList ExprList { get; set; }
  
    public OptInitOrExprListOrArrayAccessLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
