using System;
using System.Text;

namespace Compiler
{
  public class FactorAddopr : Ifactor
  {
    public ImonadicOpr monadicOpr { get; set; }
  
    public Ifactor factor { get; set; }
  
    public FactorAddopr()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
