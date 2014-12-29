using System;
using System.Text;

namespace Compiler
{
  public class RepglobImportComma : IrepglobImport
  {
    public Token COMMA { get; set; } 
  
    public IglobImport globImport { get; set; }
  
    public IrepglobImport repglobImport { get; set; }
  
    public RepglobImportComma()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
