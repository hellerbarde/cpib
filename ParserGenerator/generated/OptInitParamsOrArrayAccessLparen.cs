using System;
using System.Text;

namespace Compiler
{
  public class OptInitParamsOrArrayAccessLparen : IoptInitParamsOrArrayAccess
  {
    public IexprList exprList { get; set; }
  
    public OptInitParamsOrArrayAccessLparen()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
