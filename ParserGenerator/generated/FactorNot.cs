using System;
using System.Text;

namespace Compiler
{
  public class FactorNot : Ifactor
  {
    public ImonadicOpr monadicOpr { get; set; }
  
    public Ifactor factor { get; set; }
  
    public FactorNot()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
