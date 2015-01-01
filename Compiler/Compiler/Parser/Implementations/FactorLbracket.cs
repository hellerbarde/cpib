using System;
using System.Text;

namespace Compiler
{
  public partial class FactorLBRACKET : IFactor
  {
    public IArrayLiteral ArrayLiteral { get; set; }
  
    public FactorLBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
