using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListNOT : IOptExprList
  {
    public IExpr expr { get; set; }
  
    public IRepExprList repexprlist { get; set; }
  
    public OptExprListNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
