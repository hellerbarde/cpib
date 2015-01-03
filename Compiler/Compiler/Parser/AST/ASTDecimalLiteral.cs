using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public partial class ASTDecimalLiteral : ASTExpression
  {
    public ASTDecimalLiteral(decimal value)
    {
      this.Value = value;
    }

    public decimal Value { get; set; }

    public override string ToString()
    {
      return string.Format("{0}m", this.Value);
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTDecimalLiteral(Value: {1})", ind, Value));
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      vm.DecimalLoad(loc++, Value);
      return loc;
    }

    public override Type GetExpressionType(CheckerInformation info)
    {
      return Type.DECIMAL;
    }
  }
}