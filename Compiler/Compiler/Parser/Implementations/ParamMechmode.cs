using System;
using System.Text;

namespace Compiler
{
  public partial class ParamMECHMODE : IParam
  {
    public IOptMechmode OptMechmode { get; set; }
  
    public IOptChangemode OptChangemode { get; set; }
  
    public ITypedIdent TypedIdent { get; set; }
  
    public ParamMECHMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
