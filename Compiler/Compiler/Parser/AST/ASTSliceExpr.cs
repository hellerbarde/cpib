using System;

namespace Compiler
{
  public partial class ASTSliceExpr
  {
    public ASTSliceExpr()
    {
    }
    public ASTExpression start { get; set;}
    public int end { get; set;}
  }
}

