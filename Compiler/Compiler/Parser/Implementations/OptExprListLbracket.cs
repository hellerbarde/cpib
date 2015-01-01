using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListLBRACKET : IOptExprList
  {
    public IExpr expr { get; set; }
  
    public IRepExprList repexprlist { get; set; }
  
    public OptExprListLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
