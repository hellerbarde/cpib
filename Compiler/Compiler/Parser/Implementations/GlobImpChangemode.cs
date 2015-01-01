using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpCHANGEMODE : IGlobImp
  {
    public IOptChangemode optchangemode { get; set; }
  
    public Tokennode IDENT { get; set; } 
  
    public GlobImpCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
