using System;
using System.Text;

namespace Compiler
{
  public class GlobImportListFlowmode : IglobImportList
  {
    public IglobImport globImport { get; set; }
  
    public IrepglobImport repglobImport { get; set; }
  
    public GlobImportListFlowmode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
