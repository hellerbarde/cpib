using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpCHANGEMODE : IGlobImp
  {
    public IOptChangemode OptChangemode { get; set; }
  
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
