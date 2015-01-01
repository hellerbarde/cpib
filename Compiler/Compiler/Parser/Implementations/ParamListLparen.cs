using System;
using System.Text;

namespace Compiler
{
  public partial class ParamListLPAREN : IParamList
  {
    public Tokennode LPAREN { get; set; } 
  
    public IOptParamList OptParamList { get; set; }
  
    public Tokennode RPAREN { get; set; } 
  
    public ParamListLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
