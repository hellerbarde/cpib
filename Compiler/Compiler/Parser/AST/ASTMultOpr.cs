using Compiler;
using System;
using System.Text;
using System.Linq;
namespace Compiler
{
    public class ASTMultOpr : ASTExpression
    {
        public ASTMultOpr()
        {
            Factor = new ASTEmpty();
            RepFactor = new ASTEmpty();
        }
        public Operators Operator { get; set; }

        public IASTNode Factor { get; set; }

        public IASTNode RepFactor { get; set; }

        public void SetLeftChild(IASTNode child)
        {
      if (Factor is ASTEmpty) {
                Factor = child;
            }
      else {
                var mult = (ASTMultOpr)Factor;
                mult.SetLeftChild(child);
            }
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", Factor, Operator, RepFactor);
        }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTMultOpr(Operator: {1})", ind, Operator));
      sb.AppendLine(string.Format("{0}[Factor]:", ind));
      Factor.printAST(level + 1, sb);
      sb.AppendLine(string.Format("{0}[RepFactor]:", ind));
      RepFactor.printAST(level + 1, sb);
    }

        public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
        {
            loc = Factor.GenerateCode(loc, vm, info);
            loc = RepFactor.GenerateCode(loc, vm, info);

            var type = GetExpressionType(info);

      if (type.Type == Type.INT32) {

        switch (Operator) {
                    case Operators.TIMES:
                        vm.IntMult(loc++);
                        break;
                    case Operators.DIV:
                        vm.IntDiv(loc++);
                        break;
                    case Operators.MOD:
                        vm.IntMod(loc++);
                        break;
                    default:
                        throw new IVirtualMachine.InternalError(
                            "There's an invalid operator in ASTMultOpr. Operator: " + Operator.ToString());
                }
      }
      else if (type.Type == Type.DECIMAL) {
        switch (Operator) {
                    case Operators.TIMES:
                        vm.DecimalMult(loc++);
                        break;
                    case Operators.DIV:
                        vm.DecimalDiv(loc++);
                        break;
                    case Operators.MOD:
                        vm.DecimalMod(loc++);
                        break;
                    default:
                        throw new IVirtualMachine.InternalError(
                            "There's an invalid operator in ASTMultOpr. Operator: " + Operator.ToString());
                }
            }
      else {
                throw new IVirtualMachine.InternalError(
                            "There's an invalid operand in ASTMultOpr. operand: " + type.ToString());
            }
            return loc;
        }

    public override ASTTypeOrArray GetExpressionType(CheckerInformation info)
        {
            var termType = ((ASTExpression)Factor).GetExpressionType(info);
            var repTermType = ((ASTExpression)RepFactor).GetExpressionType(info);

      if (termType.Type == Type.INT32 && repTermType.Type == Type.INT32) {
        var type = new ASTTypeOrArray();
        type.Type = Type.INT32;
        return type;
            }

      if ((termType.Type == Type.INT32 && repTermType.Type == Type.DECIMAL)
        || (termType.Type == Type.DECIMAL && repTermType.Type == Type.INT32)
        || (termType.Type == Type.DECIMAL && repTermType.Type == Type.DECIMAL)) {
        var type = new ASTTypeOrArray();
        type.Type = Type.DECIMAL;
        return type;
            }

            throw new GrammarException(string.Format("Types {0}, {1} are not a valid combination for AddOperation {2}", termType, repTermType, this.ToString()));
        }
    }
}