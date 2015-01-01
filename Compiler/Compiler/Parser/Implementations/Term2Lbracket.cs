using System;
using System.Text;

namespace Compiler
{
  public partial class Term2LBRACKET : ITerm2
  {
    public ITerm3 Term3 { get; set; }
  
    public IRepTerm3 RepTerm3 { get; set; }
  
    public Term2LBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
