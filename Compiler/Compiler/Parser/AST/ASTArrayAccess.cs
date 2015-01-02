using System;
using System.Collections.Generic;

namespace Compiler
{
  public partial class ASTArrayAccess : ASTExpression
  {
    public ASTArrayAccess()
    {
      Accessor = new List<ASTSliceExpr>();
    }
    public ASTExpression Array { get; set; }
    public List<ASTSliceExpr> Accessor { get; set; }


  }
}

