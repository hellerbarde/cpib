using System;
using System.Text;

namespace Compiler
{
  public partial class OptInitOrExprListOrArrayAccessINIT : IOptInitOrExprListOrArrayAccess
  {
    public Tokennode INIT { get; set; } 
  
    public OptInitOrExprListOrArrayAccessINIT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
