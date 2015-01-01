using System;
using System.Text;

namespace Compiler
{
  public partial class ParamFLOWMODE : IParam
  {
    public Tokennode FLOWMODE { get; set; } 
  
    public IOptMechmode optmechmode { get; set; }
  
    public IOptChangemode optchangemode { get; set; }
  
    public ITypedIdent typedident { get; set; }
  
    public ParamFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
