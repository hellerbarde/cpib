using System;
using System.Text;

namespace Compiler
{
  public partial class Term2LITERAL : ITerm2
  {
    public ITerm3 term3 { get; set; }
  
    public IRepTerm3 repterm3 { get; set; }
  
    public Term2LITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
