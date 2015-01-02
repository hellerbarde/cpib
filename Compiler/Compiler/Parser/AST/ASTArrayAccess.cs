using System;
using System.Collections.Generic;

namespace Compiler
{
  public partial class ASTArrayAccess : ASTExpression
  {
    public ASTArrayAccess()
    {
    }
    public ASTExpression Array { get; set; }
    public List<ASTSliceExpr> Accessor { public get; set; }


  }
}

