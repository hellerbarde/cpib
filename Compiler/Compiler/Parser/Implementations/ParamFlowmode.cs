using System;
using System.Text;

namespace Compiler
{
  public partial class ParamFLOWMODE : IParam
  {
    public Tokennode FLOWMODE { get; set; } 
  
    public IOptMechmode OptMechmode { get; set; }
  
    public IOptChangemode OptChangemode { get; set; }
  
    public ITypedIdent TypedIdent { get; set; }
  
    public ParamFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
