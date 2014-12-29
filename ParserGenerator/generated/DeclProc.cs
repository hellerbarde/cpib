using System;
using System.Text;

namespace Compiler
{
  public class DeclProc : Idecl
  {
    public IprocDecl procDecl { get; set; }
  
    public DeclProc()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
