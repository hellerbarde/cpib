using System;
using System.Text;

namespace Compiler
{
  public partial class DeclIDENT : IDecl
  {
    public IStoDecl stodecl { get; set; }
  
    public DeclIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
