using System;
using System.Text;

namespace Compiler
{
  public partial class Term3IDENT : ITerm3
  {
    public IFactor Factor { get; set; }
  
    public IRepFactor RepFactor { get; set; }
  
    public Term3IDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
