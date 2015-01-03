using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTArrayAccess : ASTExpression
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

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTArrayAccess()", ind));
      sb.AppendLine(string.Format("{0}[Array]:", ind));
      Array.printAST(level + 1, sb);
      sb.AppendLine(string.Format("{0}[Accessor]:", ind));
      foreach (var a in Accessor) {
        //sb.Append(ind + " ");
        a.printAST(level + 1, sb);
      }
    }

    public override Type GetExpressionType(CheckerInformation info)
    {
      throw new NotImplementedException(); // TODO TODO
      //return Type.INT32;
    }

  }
}

