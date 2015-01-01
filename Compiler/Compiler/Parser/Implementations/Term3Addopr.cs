using System;
using System.Text;

namespace Compiler
{
  public partial class Term3ADDOPR : ITerm3
  {
    public IFactor factor { get; set; }
  
    public IRepFactor repfactor { get; set; }
  
    public Term3ADDOPR()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
