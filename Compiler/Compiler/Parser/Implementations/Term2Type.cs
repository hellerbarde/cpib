using System;
using System.Text;

namespace Compiler
{
  public partial class Term2TYPE : ITerm2
  {
    public ITerm3 Term3 { get; set; }
  
    public IRepTerm3 RepTerm3 { get; set; }
  
    public Term2TYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
