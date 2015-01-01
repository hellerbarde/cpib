using System;
using System.Text;

namespace Compiler
{
  public partial class RepGlobImpsCOMMA : IRepGlobImps
  {
    public Tokennode COMMA { get; set; } 
  
    public IGlobImp globimp { get; set; }
  
    public IRepGlobImps repglobimps { get; set; }
  
    public RepGlobImpsCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
