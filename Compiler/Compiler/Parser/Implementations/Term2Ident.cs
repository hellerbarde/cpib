using System;
using System.Text;

namespace Compiler
{
  public partial class Term2IDENT : ITerm2
  {
    public ITerm3 Term3 { get; set; }
  
    public IRepTerm3 RepTerm3 { get; set; }
  
    public Term2IDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
