using System;
using System.Text;

namespace Compiler
{
  public partial class ProgParamCHANGEMODE : IProgParam
  {
    public IOptChangemode OptChangemode { get; set; }
  
    public ITypedIdent TypedIdent { get; set; }
  
    public ProgParamCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
