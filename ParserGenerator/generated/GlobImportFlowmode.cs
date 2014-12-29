using System;
using System.Text;

namespace Compiler
{
  public class GlobImportFlowmode : IglobImport
  {
    public IoptModeFlow optModeFlow { get; set; }
  
    public IoptModeChange optModeChange { get; set; }
  
    public Token IDENT { get; set; } 
  
    public GlobImportFlowmode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
