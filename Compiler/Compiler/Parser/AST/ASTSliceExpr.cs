using System;

namespace Compiler
{
  public partial class ASTSliceExpr : IASTNode
  {
    public ASTSliceExpr()
    {
      NextExpression = new ASTEmpty();
    }

    public IASTNode NextExpression { get; set; }

    public IASTNode Start { get; set; }

    public IASTNode End { get; set; }

    public virtual int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new NotImplementedException();
      //vm.IntLoad(loc++, Value); // TODO TODO TODO
      //return loc;
    }

    public virtual Type GetExpressionType(CheckerInformation info)
    {
      throw new NotImplementedException(); // TODO TODO
      //return Type.INT32;
    }
  }
}

