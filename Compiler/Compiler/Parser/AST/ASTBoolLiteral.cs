using System;
using System.Text;
using System.Linq;


namespace Compiler
{
    public class ASTBoolLiteral : ASTExpression
    {
        public ASTBoolLiteral(bool value)
        {
            this.Value = value;
        }

        public bool Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTBoolLiteral(Value: {1})", ind, Value));
    }

        public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
        {
            vm.IntLoad(loc++, Value ? 1 : 0);
            return loc;
        }

    public override ASTTypeOrArray GetExpressionType(CheckerInformation info)
        {
            var type = new ASTTypeOrArray();
            type.Type = Type.BOOL;
            return type;
        }
    }
}