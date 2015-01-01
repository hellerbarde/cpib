using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListADDOPR : IOptExprList
  {
    public IExpr expr { get; set; }
  
    public IRepExprList repexprlist { get; set; }
  
    public OptExprListADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
