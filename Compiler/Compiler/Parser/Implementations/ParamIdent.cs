using System;
using System.Text;

namespace Compiler
{
  public partial class ParamIDENT : IParam
  {
    public IOptMechmode OptMechmode { get; set; }
  
    public IOptChangemode OptChangemode { get; set; }
  
    public ITypedIdent TypedIdent { get; set; }
  
    public ParamIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
