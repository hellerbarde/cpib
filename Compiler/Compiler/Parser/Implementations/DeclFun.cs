using System;
using System.Text;

namespace Compiler
{
  public partial class DeclFUN : IDecl
  {
    public IFunDecl FunDecl { get; set; }
  
    public DeclFUN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
