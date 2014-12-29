using System;
using System.Text;

namespace Compiler
{
  public class OptInitParamsOrArrayAccessInit : IoptInitParamsOrArrayAccess
  {
    public Token INIT { get; set; } 
  
    public OptInitParamsOrArrayAccessInit()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
