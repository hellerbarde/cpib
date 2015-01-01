using System;
using System.Text;

namespace Compiler
{
  public partial class ProgParamIDENT : IProgParam
  {
    public IOptChangemode optchangemode { get; set; }
  
    public ITypedIdent typedident { get; set; }
  
    public ProgParamIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
