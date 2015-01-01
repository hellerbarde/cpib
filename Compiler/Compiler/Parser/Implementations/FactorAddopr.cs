using System;
using System.Text;

namespace Compiler
{
  public partial class FactorADDOPR : IFactor
  {
    public IMonadicOpr monadicopr { get; set; }
  
    public IFactor factor { get; set; }
  
    public FactorADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
