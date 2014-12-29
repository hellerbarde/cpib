using System;
using System.Text;

namespace Compiler
{
  public class GlobImportListIdent : IglobImportList
  {
    public IglobImport globImport { get; set; }
  
    public IrepglobImport repglobImport { get; set; }
  
    public GlobImportListIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
