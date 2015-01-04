using System.Text;
using System;
using System.Linq;

namespace Compiler
{
    public class ASTType : ASTExpression
    {
        public Type Type { get; set; }

        public ASTExpression Expr { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", Type, Expr);
        }

    public override void printAST(int level, StringBuilder sb)
                {
      throw new NotImplementedException();
        }

            public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
        {
            if(Type != Type.DECIMAL && Type != Type.INT32){ throw new IVirtualMachine.InternalError("Use of invalid (not existing) casting type " + Type.ToString()); }
            var exprType = Expr.GetExpressionType(info);
      if(exprType.Type != Type.DECIMAL && exprType.Type != Type.INT32){ throw new IVirtualMachine.InternalError("Cannot cast from type " + exprType.ToString()); }
            loc = Expr.GenerateCode(loc, vm, info);
      if (Type != exprType.Type)
            {
        if (Type == Type.DECIMAL && exprType.Type == Type.INT32)
                {
                    vm.IntToDecimal(loc++);
                }
        else if (Type == Type.INT32 && exprType.Type == Type.DECIMAL)
                {
                    vm.DecimalToInt(loc++);
                }
                else
                {
                    throw new IVirtualMachine.InternalError("Invalid casting operation");
                }
            }
            return loc;
        }

    public override ASTTypeOrArray GetExpressionType(CheckerInformation info)
        {
      return new ASTTypeOrArray(this.Type);
        }
    }
}
