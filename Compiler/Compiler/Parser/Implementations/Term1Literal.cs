using System;
using System.Text;

namespace Compiler
{
  public partial class Term1LITERAL : ITerm1
  {
    public ITerm2 term2 { get; set; }
  
    public IRepTerm2 repterm2 { get; set; }
  
    public Term1LITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
