using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListLPAREN : IOptExprList
  {
    public IExpr expr { get; set; }
  
    public IRepExprList repexprlist { get; set; }
  
    public OptExprListLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
