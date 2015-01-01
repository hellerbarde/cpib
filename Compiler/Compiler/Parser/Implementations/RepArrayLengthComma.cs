using System;
using System.Text;

namespace Compiler
{
  public partial class RepArrayLengthCOMMA : IRepArrayLength
  {
    public Tokennode COMMA { get; set; } 
  
    public IExpr expr { get; set; }
  
    public IRepArrayLength reparraylength { get; set; }
  
    public RepArrayLengthCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
