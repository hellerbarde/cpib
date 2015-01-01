using System;
using System.Text;

namespace Compiler
{
  public partial class Term3NOT : ITerm3
  {
    public IFactor factor { get; set; }
  
    public IRepFactor repfactor { get; set; }
  
    public Term3NOT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
