using System;
using System.Text;

namespace Compiler
{
  public partial class RepParamListCOMMA : IRepParamList
  {
    public Tokennode COMMA { get; set; } 
  
    public IParam param { get; set; }
  
    public IRepParamList repparamlist { get; set; }
  
    public RepParamListCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
