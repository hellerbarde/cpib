using System;
using System.Text;

namespace Compiler
{
  public partial class OptGlobInitsINIT : IOptGlobInits
  {
    public Tokennode INIT { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IRepIdents RepIdents { get; set; }
  
    public OptGlobInitsINIT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
