﻿using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTNot : ASTExpression
  {
    public ASTExpression Expr { get; set; }


    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTNot()", ind));
      sb.AppendLine(string.Format("{0}[Expr]:", ind));
      Expr.printAST(level + 1, sb);
    }


    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      loc = Expr.GenerateCode(loc, vm, info);

      var type = GetExpressionType(info);

      if (type.Type == Type.BOOL) {
        //1 NE 1 == 0
        //0 NE 1 == 1
        vm.IntLoad(loc++, 1);
        vm.IntNE(loc++);
      }
      else {
        throw new IVirtualMachine.InternalError(
          "Cannot negate Non-Bool value " + Expr.ToString());
      }

      return loc;
    }

    public override ASTTypeOrArray GetExpressionType(CheckerInformation info)
    {
      return Expr.GetExpressionType(info);
    }
  }
}
