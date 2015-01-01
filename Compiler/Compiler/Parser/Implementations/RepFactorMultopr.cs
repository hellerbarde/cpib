using System;
using System.Text;

namespace Compiler
{
  public partial class RepFactorMULTOPR : IRepFactor
  {
    public Tokennode MULTOPR { get; set; } 
  
    public IFactor factor { get; set; }
  
    public IRepFactor repfactor { get; set; }
  
    public RepFactorMULTOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
