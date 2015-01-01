using System;
using System.Text;

namespace Compiler
{
  public partial class Term1LBRACKET : ITerm1
  {
    public ITerm2 Term2 { get; set; }
  
    public IRepTerm2 RepTerm2 { get; set; }
  
    public Term1LBRACKET()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
