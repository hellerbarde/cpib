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

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new NotImplementedException();
      //vm.IntLoad(loc++, Value); // TODO TODO TODO
      //return loc;
    }

    public override Type GetExpressionType(CheckerInformation info)
    {
      throw new NotImplementedException(); // TODO TODO
      //return Type.INT32;
    }

  }
}

