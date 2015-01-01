using System;
using System.Text;

namespace Compiler
{
  public partial class DeclIDENT : IDecl
  {
    public IStoDecl StoDecl { get; set; }
  
    public DeclIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
