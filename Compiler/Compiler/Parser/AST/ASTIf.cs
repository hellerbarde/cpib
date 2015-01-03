using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;
namespace Compiler
{
    public class ASTIf : ASTCpsCmd
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
        loc = Condition.GenerateCode(loc, vm, info);
        int condJumpLoc = loc++; //Placeholder
        foreach (ASTCpsCmd cmd in TrueCommands)
        {
            loc = cmd.GenerateCode(loc, vm, info);
        }
        int uncondJumpLoc = loc++; //Placeholder2
        vm.CondJump(condJumpLoc, loc); //Fill in Placeholder
        foreach (ASTCpsCmd cmd in FalseCommands)
        {
            loc = cmd.GenerateCode(loc, vm, info);
        }
        vm.UncondJump(uncondJumpLoc, loc); //Fill in Placeholder2
        return loc;
    }
  }
}