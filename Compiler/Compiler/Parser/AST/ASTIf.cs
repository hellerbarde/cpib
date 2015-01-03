using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;
namespace Compiler
{
  public partial class ASTIf : ASTCpsCmd
  {
    public IASTNode Condition { get; set; }

    public List<ASTCpsCmd> TrueCommands { get; set; }

    public List<ASTCpsCmd> FalseCommands { get; set; }

    public override string ToString()
    {
      return string.Format(@"if {0} then", Condition);
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTIf()", ind));
      sb.AppendLine(string.Format("{0}[Condition]:", ind));
      Condition.printAST(level + 1, sb);
      sb.AppendLine(string.Format("{0}[TrueCommands]:", ind));
      foreach (var a in TrueCommands) {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[FalseCommands]:", ind));
      foreach (var a in FalseCommands) {
        a.printAST(level + 1, sb);
      }
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new System.NotImplementedException();
    }
  }
}