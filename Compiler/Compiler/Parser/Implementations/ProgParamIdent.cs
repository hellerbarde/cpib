using System;
using System.Text;

namespace Compiler
{
  public partial class ProgParamIDENT : IProgParam
  {
    public IOptChangemode OptChangemode { get; set; }
  
    public ITypedIdent TypedIdent { get; set; }
  
    public ProgParamIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
