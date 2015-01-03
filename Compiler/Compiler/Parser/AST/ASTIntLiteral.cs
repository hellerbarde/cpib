using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTIntLiteral : ASTExpression
  {
    public ASTIntLiteral(int value)
    {
      this.Value = value;
    }

    public int Value { get; set; }

    public override string ToString()
    {
      return Value.ToString();
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTIntLiteral(Value: {1})", ind, Value));
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      vm.IntLoad(loc++, Value);
      return loc;
    }

    public override Type GetExpressionType(CheckerInformation info)
    {
      return Type.INT32;
    }
  }
}