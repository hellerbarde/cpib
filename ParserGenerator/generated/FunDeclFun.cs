using System;
using System.Text;

namespace Compiler
{
  public class FunDeclFun : IfunDecl
  {
    public Token FUN { get; set; } 
  
    public Token IDENT { get; set; } 
  
    public IparamList paramList { get; set; }
  
    public Token RETURNS { get; set; } 
  
    public IstoreDecl storeDecl { get; set; }
  
    public IoptGlobImportList optGlobImportList { get; set; }
  
    public IoptCpsStoDecl optCpsStoDecl { get; set; }
  
    public IblockCmd blockCmd { get; set; }
  
    public FunDeclFun()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
