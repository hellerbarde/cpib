using System;
using System.Text;

namespace Compiler
{
  public partial class ExprListLPAREN : IExprList
  {
    public Tokennode LPAREN { get; set; } 
  
    public IOptExprList optexprlist { get; set; }
  
    public Tokennode RPAREN { get; set; } 
  
    public ExprListLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
