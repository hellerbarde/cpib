using System;
using System.Text;

namespace Compiler
{
  public partial class RepProgParamListCOMMA : IRepProgParamList
  {
    public Tokennode COMMA { get; set; } 
  
    public IProgParam progparam { get; set; }
  
    public IRepProgParamList repprogparamlist { get; set; }
  
    public RepProgParamListCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
