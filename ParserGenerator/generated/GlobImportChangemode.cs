using System;
using System.Text;

namespace Compiler
{
  public class GlobImportChangemode : IglobImport
  {
    public IoptModeFlow optModeFlow { get; set; }
  
    public IoptModeChange optModeChange { get; set; }
  
    public Token IDENT { get; set; } 
  
    public GlobImportChangemode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
