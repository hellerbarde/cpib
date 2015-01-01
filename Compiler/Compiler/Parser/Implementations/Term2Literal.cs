using System;
using System.Text;

namespace Compiler
{
  public partial class Term2LITERAL : ITerm2
  {
    public ITerm3 Term3 { get; set; }
  
    public IRepTerm3 RepTerm3 { get; set; }
  
    public Term2LITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
