using System;
using System.Text;

namespace Compiler
{
  public partial class FactorNOT : IFactor
  {
    public IMonadicOpr monadicopr { get; set; }
  
    public IFactor factor { get; set; }
  
    public FactorNOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
