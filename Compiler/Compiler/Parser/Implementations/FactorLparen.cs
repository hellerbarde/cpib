using System;
using System.Text;

namespace Compiler
{
  public partial class FactorLPAREN : IFactor
  {
    public Tokennode LPAREN { get; set; } 
  
    public IExpr expr { get; set; }
  
    public Tokennode RPAREN { get; set; } 
  
    public FactorLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
