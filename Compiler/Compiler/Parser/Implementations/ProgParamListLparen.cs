using System;
using System.Text;

namespace Compiler
{
  public partial class ProgParamListLPAREN : IProgParamList
  {
    public Tokennode LPAREN { get; set; } 
  
    public IOptProgParamList OptProgParamList { get; set; }
  
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
