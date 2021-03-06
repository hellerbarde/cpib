using System;
using System.Text;
using System.Linq;

namespace Compiler
{
    public class ASTRelOpr : ASTExpression
    {
        public ASTRelOpr()
        {
            Term = new ASTEmpty();
            RepTerm = new ASTEmpty();
        }
        public Operators Operator { get; set; }

        public IASTNode Term { get; set; }

        public IASTNode RepTerm { get; set; }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", Term, Operator, RepTerm);
        }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTRelOpr(Operator: {1})", ind, Operator));
      sb.AppendLine(string.Format("{0}[Term]:", ind));
      Term.printAST(level + 1, sb);
      sb.AppendLine(string.Format("{0}[RepTerm]:", ind));
      RepTerm.printAST(level + 1, sb);
    }

        public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
        {
            loc = Term.GenerateCode(loc, vm, info);
            loc = RepTerm.GenerateCode(loc, vm, info);

            var termType = ((ASTExpression)Term).GetExpressionType(info);
            var repTermType = ((ASTExpression)RepTerm).GetExpressionType(info);

      if (termType.Type == Type.INT32 && repTermType.Type == Type.INT32)
            {
                switch (Operator)
                {
                    case Operators.EQ:
                        vm.IntEQ(loc++);
                        break;
                    case Operators.NE:
                        vm.IntNE(loc++);
                        break;
                    case Operators.LT:
                        vm.IntLT(loc++);
                        break;
                    case Operators.LE:
                        vm.IntLE(loc++);
                        break;
                    case Operators.GT:
                        vm.IntGT(loc++);
                        break;
                    case Operators.GE:
                        vm.IntGE(loc++);
                        break;
                    default:
                        throw new IVirtualMachine.InternalError("There's an invalid operator in ASTRelOpr. Operator: " + Operator.ToString());
                }
            }
      else if ((termType.Type == Type.INT32 && repTermType.Type == Type.DECIMAL)
        || (termType.Type == Type.DECIMAL && repTermType.Type == Type.INT32)
        || (termType.Type == Type.DECIMAL && repTermType.Type == Type.DECIMAL)) {
        switch (Operator) {
                    case Operators.EQ:
                        vm.DecimalEQ(loc++);
                        break;
                    case Operators.NE:
                        vm.DecimalNE(loc++);
                        break;
                    case Operators.LT:
                        vm.DecimalLT(loc++);
                        break;
                    case Operators.LE:
                        vm.DecimalLE(loc++);
                        break;
                    case Operators.GT:
                        vm.DecimalGT(loc++);
                        break;
                    case Operators.GE:
                        vm.DecimalGE(loc++);
                        break;
                    default:
                        throw new IVirtualMachine.InternalError("There's an invalid operator in ASTRelOpr. Operator: " + Operator.ToString());
                }
            }
      else {
                throw new IVirtualMachine.InternalError("There's an invalid operand in ASTRelOpr. Operand: " + termType.ToString() + ", " + repTermType.ToString());
            }


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