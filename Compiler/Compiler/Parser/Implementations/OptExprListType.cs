using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListTYPE : IOptExprList
  {
    public IExpr expr { get; set; }
  
    public IRepExprList repexprlist { get; set; }
  
    public OptExprListTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
