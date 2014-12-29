using System;
using System.Text;

namespace Compiler
{
  public class GlobImportIdent : IglobImport
  {
    public IoptModeFlow optModeFlow { get; set; }
  
    public IoptModeChange optModeChange { get; set; }
  
    public Token IDENT { get; set; } 
  
    public GlobImportIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
