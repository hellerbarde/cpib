using System;
using System.Text;

namespace Compiler
{
  public partial class ParamCHANGEMODE : IParam
  {
    public IOptMechmode optmechmode { get; set; }
  
    public IOptChangemode optchangemode { get; set; }
  
    public ITypedIdent typedident { get; set; }
  
    public ParamCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
