using System;
using System.Text;

namespace Compiler
{
  public partial class RepIdentsCOMMA : IRepIdents
  {
    public Tokennode COMMA { get; set; } 
  
    public Tokennode IDENT { get; set; } 
  
    public IRepIdents repidents { get; set; }
  
    public RepIdentsCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
