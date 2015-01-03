using System;
using System.Text;
using System.Linq;


namespace Compiler
{
    public class ASTCmdDebugIn : ASTCpsCmd
    {
        public ASTExpression Expr { get; set; }

    public override void printAST(int level, StringBuilder sb)
            {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTCmdDebugIn()", ind));
      sb.AppendLine(string.Format("{0}[Expr]:", ind));
      Expr.printAST(level + 1, sb);
            }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      loc = Expr.GenerateLValue(loc, vm, info);
            switch (Expr.GetExpressionType(info))
            {
                case Type.INT32:
                    vm.IntInput(loc++, "DEBUGIN");
                    break;
                case Type.BOOL:
                    vm.BoolInput(loc++, "DEBUGIN");
                    break;
                case Type.DECIMAL:
                    vm.DecimalInput(loc++, "DEBUGIN");
                    break;
            }
            return loc;
        }
    }
}