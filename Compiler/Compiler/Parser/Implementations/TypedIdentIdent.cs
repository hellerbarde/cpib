using System;
using System.Text;

namespace Compiler
{
  public partial class TypedIdentIDENT : ITypedIdent
  {
    public Tokennode IDENT { get; set; } 
  
    public Tokennode COLON { get; set; } 
  
    public ITypeOrArray typeorarray { get; set; }
  
    public TypedIdentIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
