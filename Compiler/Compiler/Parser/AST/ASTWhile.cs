using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
namespace Compiler
{
  public partial class ASTWhile : ASTCpsCmd
  {
    public IASTNode Condition { get; set; }

    public List<ASTCpsCmd> Commands { get; set; }

    public override string ToString()
    {
      return string.Format("while {0} do", Condition);
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTWhile()", ind));
      sb.AppendLine(string.Format("{0}[Condition]:", ind));
      Condition.printAST(level + 1, sb);
      sb.AppendLine(string.Format("{0}[Commands]:", ind));
      foreach (var a in Commands) {
        a.printAST(level + 1, sb);
      }
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new System.NotImplementedException();
    }
  }
}