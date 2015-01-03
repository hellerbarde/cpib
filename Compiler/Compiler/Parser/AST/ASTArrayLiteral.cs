using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;


namespace Compiler
{
  public class ASTArrayLiteral : ASTExpression
  {
    public ASTArrayLiteral()
    {
      this.Value = new List<ASTExpression>();
    }

    public List<ASTExpression> Value { get; set; }

    public override string ToString()
    {
      return Value.ToString();
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new NotImplementedException();
      //vm.IntLoad(loc++, Value); // TODO TODO TODO
      //return loc;
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTArrayLiteral()", ind));
      sb.AppendLine(string.Format("{0}[Value]:", ind));
      foreach (var a in Value) {
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