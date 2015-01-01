using System;
using System.Text;

namespace Compiler
{
  public partial class ArrayContentLITERAL : IArrayContent
  {
    public Tokennode LITERAL { get; set; } 
  
    public IRepLiteral RepLiteral { get; set; }
  
    public ArrayContentLITERAL()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
