using System;
using System.Text;

namespace Compiler
{
  public partial class ParamIDENT : IParam
  {
    public IOptMechmode optmechmode { get; set; }
  
    public IOptChangemode optchangemode { get; set; }
  
    public ITypedIdent typedident { get; set; }
  
    public ParamIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
