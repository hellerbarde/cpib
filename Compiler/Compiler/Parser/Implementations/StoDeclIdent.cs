using System;
using System.Text;

namespace Compiler
{
  public partial class StoDeclIDENT : IStoDecl
  {
    public ITypedIdent TypedIdent { get; set; }
  
    public StoDeclIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
