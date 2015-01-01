using System;
using System.Text;

namespace Compiler
{
  public partial class FactorTYPE : IFactor
  {
    public Tokennode TYPE { get; set; } 
  
    public Tokennode LPAREN { get; set; } 
  
    public IExpr expr { get; set; }
  
    public Tokennode RPAREN { get; set; } 
  
    public FactorTYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
