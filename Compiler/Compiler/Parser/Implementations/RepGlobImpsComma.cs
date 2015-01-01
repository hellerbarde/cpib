using System;
using System.Text;

namespace Compiler
{
  public partial class RepGlobImpsCOMMA : IRepGlobImps
  {
    public Tokennode COMMA { get; set; } 
  
    public IGlobImp GlobImp { get; set; }
  
    public IRepGlobImps RepGlobImps { get; set; }
  
    public RepGlobImpsCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
