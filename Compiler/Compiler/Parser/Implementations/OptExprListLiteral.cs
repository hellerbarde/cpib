using System;
using System.Text;

namespace Compiler
{
  public partial class OptExprListLITERAL : IOptExprList
  {
    public IExpr expr { get; set; }
  
    public IRepExprList repexprlist { get; set; }
  
    public OptExprListLITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
