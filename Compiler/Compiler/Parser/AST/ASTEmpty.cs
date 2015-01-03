using System.Text;
using System;
using System.Linq;

namespace Compiler
{
  public partial class ASTEmpty:IASTNode
  {
    public int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      return loc;
    }

    public void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTEmpty()", ind));
    }
  }
}