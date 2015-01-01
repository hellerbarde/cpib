using System;
using System.Text;

namespace Compiler
{
  public partial class Term3ADDOPR : ITerm3
  {
    public IFactor Factor { get; set; }
  
    public IRepFactor RepFactor { get; set; }
  
    public Term3ADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
