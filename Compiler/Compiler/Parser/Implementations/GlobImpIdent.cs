using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpIDENT : IGlobImp
  {
    public IOptChangemode OptChangemode { get; set; }
  
    public Tokennode IDENT { get; set; } 
  
    public GlobImpIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
