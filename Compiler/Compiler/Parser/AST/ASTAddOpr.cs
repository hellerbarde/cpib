using System.Text;
using System;
using System.Linq;


namespace Compiler
{
  public class ASTAddOpr : ASTExpression
  {
    public ASTAddOpr()
    {
      Term = new ASTEmpty();
      RepTerm = new ASTEmpty();
    }

    public Operators Operator { get; set; }

    public IASTNode Term { get; set; }

    public IASTNode RepTerm { get; set; }

    public void SetLeftChild(IASTNode child)
    {
      if (Term is ASTEmpty) {
        Term = child;
      }
      else {
        var mult = (ASTAddOpr)Term;
        mult.SetLeftChild(child);
      }
    }

    public override string ToString()
    {
      return string.Format("({0} {1} {2})", Term, Operator, RepTerm);
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTAddOpr(Operator: {1})", ind, Operator));
      sb.AppendLine(string.Format("{0}[Term]:", ind));
      Term.printAST(level + 1, sb);
      sb.AppendLine(string.Format("{0}[RepTerm]:", ind));
      RepTerm.printAST(level + 1, sb);
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      loc = Term.GenerateCode(loc, vm, info);
      loc = RepTerm.GenerateCode(loc, vm, info);

      var type = GetExpressionType(info);

      if (type.Type == Type.INT32) {
        switch (Operator) {
          case Operators.PLUS:
            vm.IntAdd(loc++);
            break;
          case Operators.MINUS:
            vm.IntSub(loc++);
            break;
          default:
            throw new IVirtualMachine.InternalError(
              "There's an invalid operator in ASTAddOpr. Operator: " + Operator.ToString());
        }
      }
      else if (type.Type == Type.DECIMAL) {
        switch (Operator) {
          case Operators.PLUS:
            vm.DecimalAdd(loc++);
            break;
          case Operators.MINUS:
            vm.DecimalSub(loc++);
            break;
          default:
            throw new IVirtualMachine.InternalError(
              "There's an invalid operator in ASTAddOpr. Operator: " + Operator.ToString());
        }
      }
      else {
        throw new IVirtualMachine.InternalError(
          "There's an invalid operand type in ASTAddOpr. type: " + type.ToString());
      }
      return loc;
    }

    public override ASTTypeOrArray GetExpressionType(CheckerInformation info)
    {
      var termType = ((ASTExpression)Term).GetExpressionType(info);
      var repTermType = ((ASTExpression)RepTerm).GetExpressionType(info);

      if (termType.Type == Type.INT32 && repTermType.Type == Type.INT32) {

        return new ASTTypeOrArray(Type.INT32);
      }

      if ((termType.Type == Type.INT32 && repTermType.Type == Type.DECIMAL)
        || (termType.Type == Type.DECIMAL && repTermType.Type == Type.INT32)
        || (termType.Type == Type.DECIMAL && repTermType.Type == Type.DECIMAL)) {
        return new ASTTypeOrArray(Type.DECIMAL);
      }

      throw new GrammarException(string.Format("Types {0}, {1} are not a valid combination for AddOperation {2}", termType, repTermType, this.ToString()));
    }
  }
}