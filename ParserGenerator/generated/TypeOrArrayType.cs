using System;
using System.Text;

namespace Compiler
{
  public class TypeOrArrayType : ItypeOrArray
  {
    public Token TYPE { get; set; } 
  
    public TypeOrArrayType()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
