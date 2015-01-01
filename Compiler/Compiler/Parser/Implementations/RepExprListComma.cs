using System;
using System.Text;

namespace Compiler
{
  public partial class RepExprListCOMMA : IRepExprList
  {
    public Tokennode COMMA { get; set; } 
  
    public IExpr expr { get; set; }
  
    public IRepExprList repexprlist { get; set; }
  
    public RepExprListCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
