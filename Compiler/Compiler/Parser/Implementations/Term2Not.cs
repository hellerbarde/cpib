using System;
using System.Text;

namespace Compiler
{
  public partial class Term2NOT : ITerm2
  {
    public ITerm3 term3 { get; set; }
  
    public IRepTerm3 repterm3 { get; set; }
  
    public Term2NOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
