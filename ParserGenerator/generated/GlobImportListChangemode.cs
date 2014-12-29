using System;
using System.Text;

namespace Compiler
{
  public class GlobImportListChangemode : IglobImportList
  {
    public IglobImport globImport { get; set; }
  
    public IrepglobImport repglobImport { get; set; }
  
    public GlobImportListChangemode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
