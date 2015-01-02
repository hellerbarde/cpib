using System;

namespace Compiler
{
  public partial class ASTSliceExpr:IASTNode
  {
    public ASTSliceExpr()
    {
      NextExpression = new ASTEmpty();
    }

    public IASTNode NextExpression { get; set; }

    public IASTNode Start { get; set;}
    public IASTNode End { get; set;}
  }
}

