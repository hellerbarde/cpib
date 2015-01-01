using System;
using System.Text;

namespace Compiler
{
  public partial class Term1LPAREN : ITerm1
  {
    public ITerm2 Term2 { get; set; }
  
    public IRepTerm2 RepTerm2 { get; set; }
  
    public Term1LPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
