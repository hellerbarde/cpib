using System.Text;
using System;
using System.Linq;
namespace Compiler
{
  public abstract class ASTExpression : IASTNode
  {
    public ASTExpression()
    {
      NextExpression = new ASTEmpty();
    }

    public IASTNode NextExpression { get; set; }

    public abstract void printAST(int level, StringBuilder sb);


    public virtual int GenerateLValue(int loc, IVirtualMachine vm, CheckerInformation info)
    {
        throw new IVirtualMachine.InternalError("Expression is no LValue");
    }

    public abstract int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info);

    public abstract Type GetExpressionType(CheckerInformation info);
  }
}