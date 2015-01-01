using System;
using System.Text;

namespace Compiler
{
  public partial class ProgParamFLOWMODE : IProgParam
  {
    public Tokennode FLOWMODE { get; set; } 
  
    public IOptChangemode OptChangemode { get; set; }
  
    public ITypedIdent TypedIdent { get; set; }
  
    public ProgParamFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
