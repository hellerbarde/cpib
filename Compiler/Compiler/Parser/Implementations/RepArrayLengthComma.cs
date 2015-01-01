using System;
using System.Text;

namespace Compiler
{
  public partial class RepArrayLengthCOMMA : IRepArrayLength
  {
    public Tokennode COMMA { get; set; } 
  
    public IExpr Expr { get; set; }
  
    public IRepArrayLength RepArrayLength { get; set; }
  
    public RepArrayLengthCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
