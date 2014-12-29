using System;
using System.Text;

namespace Compiler
{
  public class OptInitParamsOrArrayAccessLbracket : IoptInitParamsOrArrayAccess
  {
    public IarrayIndex arrayIndex { get; set; }
  
    public OptInitParamsOrArrayAccessLbracket()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
