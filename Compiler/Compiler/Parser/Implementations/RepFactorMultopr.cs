using System;
using System.Text;

namespace Compiler
{
  public partial class RepFactorMULTOPR : IRepFactor
  {
    public Tokennode MULTOPR { get; set; } 
  
    public IFactor Factor { get; set; }
  
    public IRepFactor RepFactor { get; set; }
  
    public RepFactorMULTOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
