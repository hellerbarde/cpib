using System;
using System.Text;

namespace Compiler
{
  public partial class TypeOrArrayARRAY : ITypeOrArray
  {
    public Tokennode ARRAY { get; set; } 
  
    public Tokennode LPAREN { get; set; } 
  
    public IExpr Expr { get; set; }
  
    public IRepArrayLength RepArrayLength { get; set; }
  
    public Tokennode RPAREN { get; set; } 
  
    public Tokennode TYPE { get; set; } 
  
    public TypeOrArrayARRAY()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
