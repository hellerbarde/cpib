using System;
using System.Text;
using System.Linq;


namespace Compiler
{
  public partial class ASTCmdDebugOut : ASTCpsCmd
  {
    public IASTNode Expr { get; set; }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTCmdDebugIn()", ind));
      sb.AppendLine(string.Format("{0}[Expr]:", ind));
      Expr.printAST(level + 1, sb);
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      loc = Expr.GenerateCode(loc, vm, info);
      var type = ((ASTExpression)Expr).GetExpressionType(info);
      if (type == Type.INT32) {
        vm.IntOutput(loc++, "DEBUGOUT");
      }
      else if (type == Type.DECIMAL) {
        vm.DecimalOutput(loc++, "DEBUGOUT");
      }
      else if (type == Type.BOOL) {
        vm.BoolOutput(loc++, "DEBUGOUT");
      }
      return loc;
    }
  }
}