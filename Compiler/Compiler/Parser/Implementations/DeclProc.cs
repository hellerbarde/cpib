using System;
using System.Text;

namespace Compiler
{
  public partial class DeclPROC : IDecl
  {
    public IProcDecl ProcDecl { get; set; }
  
    public DeclPROC()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
