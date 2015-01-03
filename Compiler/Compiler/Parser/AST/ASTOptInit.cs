using System.Text;
using System;
using System.Linq;

namespace Compiler
{
    public class ASTOptInit : IASTNode
    {
        public string Ident { get; set; }

        public IASTNode NextInit { get; set; }

    public void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTOptInit(Ident: {1})", ind, Ident));
    }

        public int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
        {
            throw new IVirtualMachine.InternalError("ASTOptInit.GenerateCode was called. This should never happen!");
        }
    }
}