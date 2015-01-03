using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public partial class ASTCmdSkip : ASTCpsCmd
  {

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTCmdSkip()", ind));
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new System.NotImplementedException();
    }
  }
}