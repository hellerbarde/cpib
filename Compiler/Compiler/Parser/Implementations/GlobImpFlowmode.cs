using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpFLOWMODE : IGlobImp
  {
    public Tokennode FLOWMODE { get; set; } 
  
    public IOptChangemode OptChangemode { get; set; }
  
    public Tokennode IDENT { get; set; } 
  
    public GlobImpFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
