using System;
using System.Text;

namespace Compiler
{
  public class MonadicOprNot : ImonadicOpr
  {
    public Token NOT { get; set; } 
  
    public MonadicOprNot()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
