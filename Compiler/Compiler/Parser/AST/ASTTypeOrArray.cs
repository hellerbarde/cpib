using System;
using System.Collections.Generic;

namespace Compiler
{
  public partial class ASTTypeOrArray : IASTNode
  {
    public ASTTypeOrArray()
    {
    }

    public Boolean isArray { get; set; }

    public Type Type { get; set; }

    public List<int> dimensions { get; set; }
 

    //public IASTNode Expr { get; set; }

    public override string ToString()
    {
      return "";
      //return string.Format("{0}({1})", Type, Expr);
    }
  }
}

