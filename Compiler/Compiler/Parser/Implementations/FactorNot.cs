using System;
using System.Text;

namespace Compiler
{
  public partial class FactorNOT : IFactor
  {
    public IMonadicOpr MonadicOpr { get; set; }
  
    public IFactor Factor { get; set; }
  
    public FactorNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
