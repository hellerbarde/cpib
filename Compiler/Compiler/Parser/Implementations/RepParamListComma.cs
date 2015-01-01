using System;
using System.Text;

namespace Compiler
{
  public partial class RepParamListCOMMA : IRepParamList
  {
    public Tokennode COMMA { get; set; } 
  
    public IParam Param { get; set; }
  
    public IRepParamList RepParamList { get; set; }
  
    public RepParamListCOMMA()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
