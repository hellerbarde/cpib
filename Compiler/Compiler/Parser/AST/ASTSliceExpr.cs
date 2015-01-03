using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTSliceExpr : IASTNode
  {
    public ASTSliceExpr()
    {
      NextExpression = new ASTEmpty();
    }

    public IASTNode NextExpression { get; set; }

    public IASTNode Start { get; set; }

    public IASTNode End { get; set; }

    public void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      if (End is ASTEmpty) {
        sb.Append(string.Format("[{0}]", Start));
      }
      sb.AppendLine(string.Format("{0}ASTSliceExpr()", ind));

      sb.AppendLine(string.Format("{0}[Start]:", ind));
      Start.printAST(level + 1, sb);

      sb.AppendLine(string.Format("{0}[End]:", ind));
      End.printAST(level + 1, sb);
    }

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

