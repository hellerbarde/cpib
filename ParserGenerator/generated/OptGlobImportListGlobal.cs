using System;
using System.Text;

namespace Compiler
{
  public class OptGlobImportListGlobal : IoptGlobImportList
  {
    public Token GLOBAL { get; set; } 
  
    public IglobImportList globImportList { get; set; }
  
    public OptGlobImportListGlobal()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
