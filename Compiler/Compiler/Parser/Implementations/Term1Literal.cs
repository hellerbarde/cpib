using System;
using System.Text;

namespace Compiler
{
  public partial class Term1LITERAL : ITerm1
  {
    public ITerm2 Term2 { get; set; }
  
    public IRepTerm2 RepTerm2 { get; set; }
  
    public Term1LITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
