using System;
using System.Text;

namespace Compiler
{
  public partial class ProgParamCHANGEMODE : IProgParam
  {
    public IOptChangemode optchangemode { get; set; }
  
    public ITypedIdent typedident { get; set; }
  
    public ProgParamCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
