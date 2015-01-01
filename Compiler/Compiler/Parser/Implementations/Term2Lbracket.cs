using System;
using System.Text;

namespace Compiler
{
  public partial class Term2LBRACKET : ITerm2
  {
    public ITerm3 term3 { get; set; }
  
    public IRepTerm3 repterm3 { get; set; }
  
    public Term2LBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
