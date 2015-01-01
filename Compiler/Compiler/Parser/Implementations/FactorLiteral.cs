using System;
using System.Text;

namespace Compiler
{
  public partial class FactorLITERAL : IFactor
  {
    public Tokennode LITERAL { get; set; } 
  
    public FactorLITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
