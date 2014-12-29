using System;
using System.Text;

namespace Compiler
{
  public class TypeOrArrayArray : ItypeOrArray
  {
    public Token ARRAY { get; set; } 
  
    public Token LPAREN { get; set; } 
  
    public Iexpr expr { get; set; }
  
    public IrepArrayLength repArrayLength { get; set; }
  
    public Token RPAREN { get; set; } 
  
    public Token TYPE { get; set; } 
  
    public TypeOrArrayArray()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
