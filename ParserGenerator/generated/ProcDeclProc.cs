using System;
using System.Text;

namespace Compiler
{
  public class ProcDeclProc : IprocDecl
  {
    public Token PROC { get; set; } 
  
    public Token IDENT { get; set; } 
  
    public IparamList paramList { get; set; }
  
    public IoptGlobImportList optGlobImportList { get; set; }
  
    public IoptCpsStoDecl optCpsStoDecl { get; set; }
  
    public IblockCmd blockCmd { get; set; }
  
    public ProcDeclProc()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
