using System;
using System.Text;

namespace Compiler
{
  public partial class FactorADDOPR : IFactor
  {
    public IMonadicOpr MonadicOpr { get; set; }
  
    public IFactor Factor { get; set; }
  
    public FactorADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
