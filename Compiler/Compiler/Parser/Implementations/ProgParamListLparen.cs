using System;
using System.Text;

namespace Compiler
{
  public partial class ProgParamListLPAREN : IProgParamList
  {
    public Tokennode LPAREN { get; set; } 
  
    public IOptProgParamList optprogparamlist { get; set; }
  
    public Tokennode RPAREN { get; set; } 
  
    public ProgParamListLPAREN()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
