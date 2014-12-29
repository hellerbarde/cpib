using System;
using System.Text;

namespace Compiler
{
  public class RepArrayIndexLbracket : IrepArrayIndex
  {
    public IarrayIndex arrayIndex { get; set; }
  
    public RepArrayIndexLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
