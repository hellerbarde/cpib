using System;
using System.Text;

namespace Compiler
{
  public partial class StoDeclIDENT : IStoDecl
  {
    public ITypedIdent typedident { get; set; }
  
    public StoDeclIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
