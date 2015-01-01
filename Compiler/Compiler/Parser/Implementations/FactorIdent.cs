using System;
using System.Text;

namespace Compiler
{
  public partial class FactorIDENT : IFactor
  {
    public Tokennode IDENT { get; set; } 
  
    public IOptInitOrExprListOrArrayAccess OptInitOrExprListOrArrayAccess { get; set; }
  
    public FactorIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
