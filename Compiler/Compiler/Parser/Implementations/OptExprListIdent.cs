using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListIDENT : IOptExprList
  {
    public IExpr expr { get; set; }
  
    public IRepExprList repexprlist { get; set; }
  
    public OptExprListIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
