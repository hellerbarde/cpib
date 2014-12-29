using System;
using System.Text;

namespace Compiler
{
  public class TypedidentIdent : Itypedident
  {
    public Token IDENT { get; set; } 
  
    public Token COLON { get; set; } 
  
    public ItypeOrArray typeOrArray { get; set; }
  
    public TypedidentIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
