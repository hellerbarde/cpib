using System;
using System.Text;

namespace Compiler
{
  public partial class ParamCHANGEMODE : IParam
  {
    public IOptMechmode OptMechmode { get; set; }
  
    public IOptChangemode OptChangemode { get; set; }
  
    public ITypedIdent TypedIdent { get; set; }
  
    public ParamCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
