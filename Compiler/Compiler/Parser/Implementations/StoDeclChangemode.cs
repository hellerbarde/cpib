using System;
using System.Text;

namespace Compiler
{
  public partial class StoDeclCHANGEMODE : IStoDecl
  {
    public Tokennode CHANGEMODE { get; set; } 
  
    public ITypedIdent TypedIdent { get; set; }
  
    public StoDeclCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
