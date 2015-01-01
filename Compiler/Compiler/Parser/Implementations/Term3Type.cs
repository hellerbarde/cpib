using System;
using System.Text;

namespace Compiler
{
  public partial class Term3TYPE : ITerm3
  {
    public IFactor Factor { get; set; }
  
    public IRepFactor RepFactor { get; set; }
  
    public Term3TYPE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
